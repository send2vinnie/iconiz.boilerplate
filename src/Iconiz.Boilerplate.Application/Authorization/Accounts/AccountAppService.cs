using System;
using System.Threading.Tasks;
using System.Web;
using Abp.Authorization;
using Abp.Configuration;
using Abp.Extensions;
using Abp.Runtime.Caching;
using Abp.Runtime.Security;
using Abp.Runtime.Session;
using Abp.UI;
using Abp.Zero.Configuration;
using Microsoft.AspNetCore.Identity;
using Iconiz.Boilerplate.Authorization.Accounts.Dto;
using Iconiz.Boilerplate.Authorization.Impersonation;
using Iconiz.Boilerplate.Authorization.Users;
using Iconiz.Boilerplate.Configuration;
using Iconiz.Boilerplate.Debugging;
using Iconiz.Boilerplate.MultiTenancy;
using Iconiz.Boilerplate.Security.Recaptcha;
using Iconiz.Boilerplate.Url;
using Iconiz.Boilerplate.Authentication.TwoFactor;
using Microsoft.EntityFrameworkCore;

namespace Iconiz.Boilerplate.Authorization.Accounts
{
    public class AccountAppService : BoilerplateAppServiceBase, IAccountAppService
    {
        public IAppUrlService AppUrlService { get; set; }

        public IRecaptchaValidator RecaptchaValidator { get; set; }

        private readonly IUserEmailer _userEmailer;
        private readonly UserRegistrationManager _userRegistrationManager;
        private readonly IImpersonationManager _impersonationManager;
        private readonly IUserLinkManager _userLinkManager;
        private readonly ICacheManager _cacheManager;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IWebUrlService _webUrlService;

        public AccountAppService(
            IUserEmailer userEmailer,
            UserRegistrationManager userRegistrationManager,
            IImpersonationManager impersonationManager,
            IUserLinkManager userLinkManager,
            ICacheManager cacheManager,
            IPasswordHasher<User> passwordHasher,
            IWebUrlService webUrlService)
        {
            _userEmailer = userEmailer;
            _userRegistrationManager = userRegistrationManager;
            _impersonationManager = impersonationManager;
            _userLinkManager = userLinkManager;
            _cacheManager = cacheManager;
            _passwordHasher = passwordHasher;
            _webUrlService = webUrlService;

            AppUrlService = NullAppUrlService.Instance;
            RecaptchaValidator = NullRecaptchaValidator.Instance;
        }

        public async Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input)
        {
            var tenant = await TenantManager.FindByTenancyNameAsync(input.TenancyName);
            if (tenant == null)
            {
                return new IsTenantAvailableOutput(TenantAvailabilityState.NotFound);
            }

            if (!tenant.IsActive)
            {
                return new IsTenantAvailableOutput(TenantAvailabilityState.InActive);
            }

            return new IsTenantAvailableOutput(TenantAvailabilityState.Available, tenant.Id,
                _webUrlService.GetServerRootAddress(input.TenancyName));
        }

        public Task<int?> ResolveTenantId(ResolveTenantIdInput input)
        {
            if (string.IsNullOrEmpty(input.c))
            {
                return Task.FromResult(AbpSession.TenantId);
            }

            var parameters = SimpleStringCipher.Instance.Decrypt(input.c);
            var query = HttpUtility.ParseQueryString(parameters);

            if (query["tenantId"] == null)
            {
                throw new Exception("Couldn't find tenant inforamtion !");
            }

            var tenantId = Convert.ToInt32(query["tenantId"]) as int?;
            return Task.FromResult(tenantId);
        }

        public async Task<RegisterOutput> Register(RegisterInput input)
        {
            User user = null;
            if (!input.EmailAddress.IsNullOrEmpty() && !input.EmailAddressValidateCode.IsNullOrEmpty())
            {
                if (await CheckForTwoFactorValidate(input.EmailAddress, input.EmailAddressValidateCode))
                    user = await _userRegistrationManager.RegisterAsync(
                        input.EmailAddress,
                        input.EmailAddress,
                        input.EmailAddress,
                        input.EmailAddress,
                        null,
                        input.Password,
                        true, false);
                else
                    throw new UserFriendlyException("验证码错误!");
            }
            else if (!input.PhoneNumber.IsNullOrEmpty() && !input.PhoneNumberValidateCode.IsNullOrEmpty())
            {
                if (await CheckForTwoFactorValidate(input.PhoneNumber, input.PhoneNumberValidateCode))
                    user = await _userRegistrationManager.RegisterAsync(
                        input.PhoneNumber,
                        input.PhoneNumber,
                        input.PhoneNumber + "@phonenumber.com",
                        input.PhoneNumber,
                        input.PhoneNumber,
                        input.Password,
                        false, true);
                else
                    throw new UserFriendlyException("验证码错误!");
            }

            return new RegisterOutput {CanLogin = user.IsActive};
        }

        private async Task<bool> CheckForTwoFactorValidate(string username, string code)
        {
            var cacheKey = "TwoFactorValidateCode@" + username;

            var cacheItem = await _cacheManager
                .GetTwoFactorCodeCache()
                .GetOrDefaultAsync(cacheKey);

            if (cacheItem != null && cacheItem.Code == code)
            {
                await _cacheManager.GetTwoFactorCodeCache().RemoveAsync(cacheKey);
                return true;
            }

            return false;
        }

        public async Task<CheckPasswordResetCodeOutput> CheckPasswordResetCode(CheckPasswordResetCodeInput input)
        {
            if (!input.EmailAddress.IsNullOrEmpty() && !input.EmailAddressValidateCode.IsNullOrEmpty())
            {
                if (await CheckForTwoFactorValidate(input.EmailAddress, input.EmailAddressValidateCode))
                {
                    var user = await GetUserByChecking(input.EmailAddress);
                    user.SetNewPasswordResetCode();
                    return new CheckPasswordResetCodeOutput
                    {
                        IsCodeValidate = true,
                        PasswordResetCode = user.PasswordResetCode,
                        UserId = user.Id
                    };
                }
            }

            if (!input.PhoneNumber.IsNullOrEmpty() && !input.PhoneNumberValidateCode.IsNullOrEmpty())
            {
                if (await CheckForTwoFactorValidate(input.PhoneNumber, input.PhoneNumberValidateCode))
                {
                    var user = await GetUserByChecking(input.PhoneNumber);
                    user.SetNewPasswordResetCode();
                    return new CheckPasswordResetCodeOutput
                    {
                        IsCodeValidate = true,
                        PasswordResetCode = user.PasswordResetCode,
                        UserId = user.Id
                    };
                }
            }

            return new CheckPasswordResetCodeOutput {IsCodeValidate = false};
        }

        public async Task<ResetPasswordOutput> ResetPassword(ResetPasswordInput input)
        {
            var user = await UserManager.GetUserByIdAsync(input.UserId);
            if (user == null || user.PasswordResetCode.IsNullOrEmpty() || user.PasswordResetCode != input.ResetCode)
            {
                throw new UserFriendlyException(L("InvalidPasswordResetCode"), L("InvalidPasswordResetCode_Detail"));
            }

            user.Password = _passwordHasher.HashPassword(user, input.Password);
            user.PasswordResetCode = null;
            user.ShouldChangePasswordOnNextLogin = false;

            await UserManager.UpdateAsync(user);

            return new ResetPasswordOutput
            {
                CanLogin = user.IsActive,
                UserName = user.UserName
            };
        }

        public async Task SendEmailActivationLink(SendEmailActivationLinkInput input)
        {
            var user = await GetUserByChecking(input.EmailAddress);
            user.SetNewEmailConfirmationCode();
            await _userEmailer.SendEmailActivationLinkAsync(
                user,
                AppUrlService.CreateEmailActivationUrlFormat(AbpSession.TenantId)
            );
        }

        public async Task ActivateEmail(ActivateEmailInput input)
        {
            var user = await UserManager.GetUserByIdAsync(input.UserId);
            if (user == null || user.EmailConfirmationCode.IsNullOrEmpty() ||
                user.EmailConfirmationCode != input.ConfirmationCode)
            {
                throw new UserFriendlyException(L("InvalidEmailConfirmationCode"),
                    L("InvalidEmailConfirmationCode_Detail"));
            }

            user.IsEmailConfirmed = true;
            user.EmailConfirmationCode = null;

            await UserManager.UpdateAsync(user);
        }

        [AbpAuthorize(AppPermissions.Pages_Administration_Users_Impersonation)]
        public virtual async Task<ImpersonateOutput> Impersonate(ImpersonateInput input)
        {
            return new ImpersonateOutput
            {
                ImpersonationToken = await _impersonationManager.GetImpersonationToken(input.UserId, input.TenantId),
                TenancyName = await GetTenancyNameOrNullAsync(input.TenantId)
            };
        }

        public virtual async Task<ImpersonateOutput> BackToImpersonator()
        {
            return new ImpersonateOutput
            {
                ImpersonationToken = await _impersonationManager.GetBackToImpersonatorToken(),
                TenancyName = await GetTenancyNameOrNullAsync(AbpSession.ImpersonatorTenantId)
            };
        }

        public virtual async Task<SwitchToLinkedAccountOutput> SwitchToLinkedAccount(SwitchToLinkedAccountInput input)
        {
            if (!await _userLinkManager.AreUsersLinked(AbpSession.ToUserIdentifier(), input.ToUserIdentifier()))
            {
                throw new Exception(L("This account is not linked to your account"));
            }

            return new SwitchToLinkedAccountOutput
            {
                SwitchAccountToken =
                    await _userLinkManager.GetAccountSwitchToken(input.TargetUserId, input.TargetTenantId),
                TenancyName = await GetTenancyNameOrNullAsync(input.TargetTenantId)
            };
        }

        private bool UseCaptchaOnRegistration()
        {
            if (DebugHelper.IsDebug)
            {
                return false;
            }

            return SettingManager.GetSettingValue<bool>(AppSettings.UserManagement.UseCaptchaOnRegistration);
        }

        private async Task<Tenant> GetActiveTenantAsync(int tenantId)
        {
            var tenant = await TenantManager.FindByIdAsync(tenantId);
            if (tenant == null)
            {
                throw new UserFriendlyException(L("UnknownTenantId{0}", tenantId));
            }

            if (!tenant.IsActive)
            {
                throw new UserFriendlyException(L("TenantIdIsNotActive{0}", tenantId));
            }

            return tenant;
        }

        private async Task<string> GetTenancyNameOrNullAsync(int? tenantId)
        {
            return tenantId.HasValue ? (await GetActiveTenantAsync(tenantId.Value)).TenancyName : null;
        }

        private async Task<User> GetUserByChecking(string inputUsername)
        {
            var user = await UserManager.FindByNameOrEmailAsync(inputUsername);
            if (user == null)
                user = await UserManager.Users.FirstOrDefaultAsync(u => u.PhoneNumber == inputUsername);

            if (user == null)
                throw new UserFriendlyException(L("InvalidUser"));

            return user;
        }
    }
}