﻿using System;
using System.Collections.Generic;
using System.Linq;
using Abp.Configuration;
using Abp.Zero.Configuration;
using Microsoft.Extensions.Configuration;

namespace Iconiz.Boilerplate.Configuration
{
    /// <summary>
    /// Defines settings for the application.
    /// See <see cref="AppSettings"/> for setting names.
    /// </summary>
    public class AppSettingProvider : SettingProvider
    {
        private readonly IConfigurationRoot _appConfiguration;

        public AppSettingProvider(IAppConfigurationAccessor configurationAccessor)
        {
            _appConfiguration = configurationAccessor.Configuration;
        }

        public override IEnumerable<SettingDefinition> GetSettingDefinitions(SettingDefinitionProviderContext context)
        {
            //Disable TwoFactorLogin by default (can be enabled by UI)
            context.Manager.GetSettingDefinition(AbpZeroSettingNames.UserManagement.TwoFactorLogin.IsEnabled).DefaultValue = false.ToString().ToLowerInvariant();

            return GetHostSettings().Union(GetTenantSettings()).Union(GetSharedSettings());
        }

        private IEnumerable<SettingDefinition> GetHostSettings()
        {
            return new[] {
                new SettingDefinition(AppSettings.TenantManagement.AllowSelfRegistration, GetFromAppSettings(AppSettings.TenantManagement.AllowSelfRegistration, "true"), isVisibleToClients: true),
                new SettingDefinition(AppSettings.TenantManagement.IsNewRegisteredTenantActiveByDefault, GetFromAppSettings(AppSettings.TenantManagement.IsNewRegisteredTenantActiveByDefault, "false")),
                new SettingDefinition(AppSettings.TenantManagement.UseCaptchaOnRegistration, GetFromAppSettings(AppSettings.TenantManagement.UseCaptchaOnRegistration, "true"), isVisibleToClients: true),
                new SettingDefinition(AppSettings.TenantManagement.DefaultEdition, GetFromAppSettings(AppSettings.TenantManagement.DefaultEdition, "")),
                new SettingDefinition(AppSettings.UserManagement.SmsVerificationEnabled, GetFromAppSettings(AppSettings.UserManagement.SmsVerificationEnabled, "false"), isVisibleToClients: true),
                new SettingDefinition(AppSettings.TenantManagement.SubscriptionExpireNotifyDayCount, GetFromAppSettings(AppSettings.TenantManagement.SubscriptionExpireNotifyDayCount, "7"), isVisibleToClients: true),
                new SettingDefinition(AppSettings.HostManagement.BillingLegalName, GetFromAppSettings(AppSettings.HostManagement.BillingLegalName, "")),
                new SettingDefinition(AppSettings.HostManagement.BillingAddress, GetFromAppSettings(AppSettings.HostManagement.BillingAddress, "")),
                new SettingDefinition(AppSettings.Recaptcha.SiteKey, GetFromSettings("Recaptcha:SiteKey"), isVisibleToClients: true),

                //UI customization options
                new SettingDefinition(AppSettings.UiManagement.LayoutType, GetFromAppSettings(AppSettings.UiManagement.LayoutType, "fluid"), isVisibleToClients: true, scopes: SettingScopes.All),
                new SettingDefinition(AppSettings.UiManagement.ContentSkin, GetFromAppSettings(AppSettings.UiManagement.ContentSkin, "light2"), isVisibleToClients: true, scopes: SettingScopes.All),

                new SettingDefinition(AppSettings.UiManagement.Header.DesktopFixedHeader, GetFromAppSettings(AppSettings.UiManagement.Header.DesktopFixedHeader, "true"),isVisibleToClients: true, scopes: SettingScopes.All),
                new SettingDefinition(AppSettings.UiManagement.Header.DesktopMinimizeMode, GetFromAppSettings(AppSettings.UiManagement.Header.DesktopMinimizeMode, ""),isVisibleToClients: true, scopes: SettingScopes.All),
                new SettingDefinition(AppSettings.UiManagement.Header.MobileFixedHeader, GetFromAppSettings(AppSettings.UiManagement.Header.MobileFixedHeader, "false"),isVisibleToClients: true, scopes: SettingScopes.All),
                new SettingDefinition(AppSettings.UiManagement.Header.Skin, GetFromAppSettings(AppSettings.UiManagement.Header.Skin, "light"),isVisibleToClients: true, scopes: SettingScopes.All),
                new SettingDefinition(AppSettings.UiManagement.Header.DisplaySubmenuArrowDesktop, GetFromAppSettings(AppSettings.UiManagement.Header.DisplaySubmenuArrowDesktop, "true"),isVisibleToClients: true, scopes: SettingScopes.All),

                new SettingDefinition(AppSettings.UiManagement.LeftAside.Position, GetFromAppSettings(AppSettings.UiManagement.LeftAside.Position, "left"), isVisibleToClients: true, scopes: SettingScopes.All),
                new SettingDefinition(AppSettings.UiManagement.LeftAside.AsideSkin, GetFromAppSettings(AppSettings.UiManagement.LeftAside.AsideSkin, "light"), isVisibleToClients: true, scopes: SettingScopes.All),
                new SettingDefinition(AppSettings.UiManagement.LeftAside.FixedAside, GetFromAppSettings(AppSettings.UiManagement.LeftAside.FixedAside, "true"),isVisibleToClients: true, scopes: SettingScopes.All),
                new SettingDefinition(AppSettings.UiManagement.LeftAside.AllowAsideMinimizing, GetFromAppSettings(AppSettings.UiManagement.LeftAside.AllowAsideMinimizing, "true"),isVisibleToClients: true, scopes: SettingScopes.All),
                new SettingDefinition(AppSettings.UiManagement.LeftAside.DefaultMinimizedAside, GetFromAppSettings(AppSettings.UiManagement.LeftAside.DefaultMinimizedAside, "false"),isVisibleToClients: true, scopes: SettingScopes.All),
                new SettingDefinition(AppSettings.UiManagement.LeftAside.AllowAsideHiding, GetFromAppSettings(AppSettings.UiManagement.LeftAside.AllowAsideHiding, "true"),isVisibleToClients: true, scopes: SettingScopes.All),
                new SettingDefinition(AppSettings.UiManagement.LeftAside.DefaultHiddenAside, GetFromAppSettings(AppSettings.UiManagement.LeftAside.DefaultHiddenAside, "false"),isVisibleToClients: true, scopes: SettingScopes.All),
                new SettingDefinition(AppSettings.UiManagement.LeftAside.SubmenuToggle, GetFromAppSettings(AppSettings.UiManagement.LeftAside.SubmenuToggle, "accordion"),isVisibleToClients: true, scopes: SettingScopes.All),
                new SettingDefinition(AppSettings.UiManagement.LeftAside.DropdownSubmenuSkin, GetFromAppSettings(AppSettings.UiManagement.LeftAside.DropdownSubmenuSkin, "inherit"),isVisibleToClients: true, scopes: SettingScopes.All),
                new SettingDefinition(AppSettings.UiManagement.LeftAside.DropdownSubmenuArrow, GetFromAppSettings(AppSettings.UiManagement.LeftAside.DropdownSubmenuArrow, "true"),isVisibleToClients: true, scopes: SettingScopes.All),

                new SettingDefinition(AppSettings.UiManagement.Footer.FixedFooter, GetFromAppSettings(AppSettings.UiManagement.Footer.FixedFooter, "false"),isVisibleToClients: true, scopes: SettingScopes.All),
                
                new SettingDefinition(AppSettings.UiManagement.Theme, GetFromAppSettings(AppSettings.UiManagement.Theme, "default"),isVisibleToClients: true, scopes: SettingScopes.All),
                // Sms config
                new SettingDefinition(AppSettings.SMSManagement.AppKey, GetFromAppSettings(AppSettings.SMSManagement.AppKey, "LTAIccbcdjr7DoKK"),isVisibleToClients: true, scopes: SettingScopes.All),
                new SettingDefinition(AppSettings.SMSManagement.AppSecret, GetFromAppSettings(AppSettings.SMSManagement.AppSecret, "fnvbeO2r8w8jKYA82K4dLHILfRPvKb"),isVisibleToClients: true, scopes: SettingScopes.All),
                new SettingDefinition(AppSettings.SMSManagement.SignName, GetFromAppSettings(AppSettings.SMSManagement.SignName, "标准资本"),isVisibleToClients: true, scopes: SettingScopes.All),
                new SettingDefinition(AppSettings.SMSManagement.UserIdentityValidateTemplateCode, GetFromAppSettings(AppSettings.SMSManagement.UserIdentityValidateTemplateCode, "SMS_137705015"),isVisibleToClients: true, scopes: SettingScopes.All),
                new SettingDefinition(AppSettings.SMSManagement.UserLoginConfirmTemplateCode, GetFromAppSettings(AppSettings.SMSManagement.UserLoginConfirmTemplateCode, "SMS_137705014"),isVisibleToClients: true, scopes: SettingScopes.All),
                new SettingDefinition(AppSettings.SMSManagement.UserLoginErrorTemplateCode, GetFromAppSettings(AppSettings.SMSManagement.UserLoginErrorTemplateCode, "SMS_137705013"),isVisibleToClients: true, scopes: SettingScopes.All),
                new SettingDefinition(AppSettings.SMSManagement.UserRegisterTemplateCode, GetFromAppSettings(AppSettings.SMSManagement.UserRegisterTemplateCode, "SMS_137705012"),isVisibleToClients: true, scopes: SettingScopes.All),
                new SettingDefinition(AppSettings.SMSManagement.UserChangePasswordTemplateCode, GetFromAppSettings(AppSettings.SMSManagement.UserChangePasswordTemplateCode, "SMS_137705011"),isVisibleToClients: true, scopes: SettingScopes.All),
                new SettingDefinition(AppSettings.SMSManagement.UserChangeInformationTemplateCode, GetFromAppSettings(AppSettings.SMSManagement.UserChangeInformationTemplateCode, "SMS_137705010"),isVisibleToClients: true, scopes: SettingScopes.All),
                // weixin config
                new SettingDefinition(AppSettings.WechatManagement.AppKey, GetFromAppSettings(AppSettings.WechatManagement.AppKey, "wxdc7dd753d441fb40"),isVisibleToClients: true, scopes: SettingScopes.All),
                new SettingDefinition(AppSettings.WechatManagement.AppSecret, GetFromAppSettings(AppSettings.WechatManagement.AppSecret, ""),isVisibleToClients: true, scopes: SettingScopes.All),
                // jinse config
                new SettingDefinition(AppSettings.JinseManagement.AccessKey, GetFromAppSettings(AppSettings.JinseManagement.AccessKey, "62d123757c01fd3818e4250a9b7402e1"),isVisibleToClients: true, scopes: SettingScopes.All),
                new SettingDefinition(AppSettings.JinseManagement.SecretKey, GetFromAppSettings(AppSettings.JinseManagement.SecretKey, "3773b2d9cc1584ee"),isVisibleToClients: true, scopes: SettingScopes.All)

            };
        }

        private IEnumerable<SettingDefinition> GetTenantSettings()
        {
            return new[]
            {
                new SettingDefinition(AppSettings.UserManagement.AllowSelfRegistration, GetFromAppSettings(AppSettings.UserManagement.AllowSelfRegistration, "true"), scopes: SettingScopes.Tenant, isVisibleToClients: true),
                new SettingDefinition(AppSettings.UserManagement.IsNewRegisteredUserActiveByDefault, GetFromAppSettings(AppSettings.UserManagement.IsNewRegisteredUserActiveByDefault, "false"), scopes: SettingScopes.Tenant),
                new SettingDefinition(AppSettings.UserManagement.UseCaptchaOnRegistration, GetFromAppSettings(AppSettings.UserManagement.UseCaptchaOnRegistration, "true"), scopes: SettingScopes.Tenant, isVisibleToClients: true),
                new SettingDefinition(AppSettings.TenantManagement.BillingLegalName, GetFromAppSettings(AppSettings.TenantManagement.BillingLegalName, ""), scopes: SettingScopes.Tenant),
                new SettingDefinition(AppSettings.TenantManagement.BillingAddress, GetFromAppSettings(AppSettings.TenantManagement.BillingAddress, ""), scopes: SettingScopes.Tenant),
                new SettingDefinition(AppSettings.TenantManagement.BillingTaxVatNo, GetFromAppSettings(AppSettings.TenantManagement.BillingTaxVatNo, ""), scopes: SettingScopes.Tenant)
            };
        }

        private IEnumerable<SettingDefinition> GetSharedSettings()
        {
            return new[]
            {
                new SettingDefinition(AppSettings.UserManagement.TwoFactorLogin.IsGoogleAuthenticatorEnabled, GetFromAppSettings(AppSettings.UserManagement.TwoFactorLogin.IsGoogleAuthenticatorEnabled, "false"), scopes: SettingScopes.Application | SettingScopes.Tenant, isVisibleToClients: true)
            };
        }

        private string GetFromAppSettings(string name, string defaultValue = null)
        {
            return GetFromSettings("App:" + name, defaultValue);
        }

        private string GetFromSettings(string name, string defaultValue = null)
        {
            return _appConfiguration[name] ?? defaultValue;
        }
    }
}
