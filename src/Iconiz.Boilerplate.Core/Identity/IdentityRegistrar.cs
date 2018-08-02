using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Iconiz.Boilerplate.Authentication.TwoFactor.Google;
using Iconiz.Boilerplate.Authorization;
using Iconiz.Boilerplate.Authorization.Roles;
using Iconiz.Boilerplate.Authorization.Users;
using Iconiz.Boilerplate.Editions;
using Iconiz.Boilerplate.MultiTenancy;

namespace Iconiz.Boilerplate.Identity
{
    public static class IdentityRegistrar
    {
        public static IdentityBuilder Register(IServiceCollection services)
        {
            services.AddLogging();

            return services.AddAbpIdentity<Tenant, User, Role>(options =>
                {
                    options.Tokens.ProviderMap[GoogleAuthenticatorProvider.Name] = new TokenProviderDescriptor(typeof(GoogleAuthenticatorProvider));
                })
                .AddAbpTenantManager<TenantManager>()
                .AddAbpUserManager<UserManager>()
                .AddAbpRoleManager<RoleManager>()
                .AddAbpEditionManager<EditionManager>()
                .AddAbpUserStore<UserStore>()
                .AddAbpRoleStore<RoleStore>()
                .AddAbpSignInManager<SignInManager>()
                .AddAbpUserClaimsPrincipalFactory<UserClaimsPrincipalFactory>()
                .AddAbpSecurityStampValidator<SecurityStampValidator>()
                .AddPermissionChecker<PermissionChecker>()
                .AddDefaultTokenProviders();
        }
    }
}
