namespace Iconiz.Boilerplate.Configuration
{
    /// <summary>
    /// Defines string constants for setting names in the application.
    /// See <see cref="AppSettingProvider"/> for setting definitions.
    /// </summary>
    public static class AppSettings
    {
        public static class HostManagement
        {
            public const string BillingLegalName = "App.HostManagement.BillingLegalName";
            public const string BillingAddress = "App.HostManagement.BillingAddress";
        }

        public static class UiManagement
        {
            public const string LayoutType = "App.UiManagement.LayoutType";
            public const string ContentSkin = "App.UiManagement.ContentSkin";
            public const string Theme = "App.UiManagement.Theme";

            public static class Header
            {
                public const string DesktopFixedHeader = "App.UiManagement.Header.DesktopFixedHeader";
                public const string DesktopMinimizeMode = "App.UiManagement.Header.DesktopMinimizeMode";
                public const string MobileFixedHeader = "App.UiManagement.Header.MobileFixedHeader";
                public const string Skin = "App.UiManagement.Header.Skin";
                public const string DisplaySubmenuArrowDesktop = "App.UiManagement.Header.DisplaySubmenuArrow_Desktop";
            }

            public static class LeftAside
            {
                public const string Position = "App.UiManagement.Left.Position";
                public const string AsideSkin = "App.UiManagement.Left.AsideSkin";
                public const string FixedAside = "App.UiManagement.Left.FixedAside";
                public const string AllowAsideMinimizing = "App.UiManagement.Left.AllowAsideMinimizing";
                public const string DefaultMinimizedAside = "App.UiManagement.Left.DefaultMinimizedAside";
                public const string AllowAsideHiding = "App.UiManagement.Left.AllowAsideHiding";
                public const string DefaultHiddenAside = "App.UiManagement.Left.DefaultHiddenAside";
                public const string SubmenuToggle = "App.UiManagement.Left.SubmenuToggle";
                public const string DropdownSubmenuSkin = "App.UiManagement.Left.DropdownSubmenuSkin";
                public const string DropdownSubmenuArrow = "App.UiManagement.Left.DropdownSubmenuArrow";
            }

            public static class Footer
            {
                public const string FixedFooter = "App.UiManagement.Footer.FixedFooter";
            }
        }


        public static class TenantManagement
        {
            public const string AllowSelfRegistration = "App.TenantManagement.AllowSelfRegistration";

            public const string IsNewRegisteredTenantActiveByDefault =
                "App.TenantManagement.IsNewRegisteredTenantActiveByDefault";

            public const string UseCaptchaOnRegistration = "App.TenantManagement.UseCaptchaOnRegistration";
            public const string DefaultEdition = "App.TenantManagement.DefaultEdition";

            public const string SubscriptionExpireNotifyDayCount =
                "App.TenantManagement.SubscriptionExpireNotifyDayCount";

            public const string BillingLegalName = "App.UserManagement.BillingLegalName";
            public const string BillingAddress = "App.UserManagement.BillingAddress";
            public const string BillingTaxVatNo = "App.UserManagement.BillingTaxVatNo";
        }

        public static class UserManagement
        {
            public static class TwoFactorLogin
            {
                public const string IsGoogleAuthenticatorEnabled =
                    "App.UserManagement.TwoFactorLogin.IsGoogleAuthenticatorEnabled";
            }

            public const string AllowSelfRegistration = "App.UserManagement.AllowSelfRegistration";

            public const string IsNewRegisteredUserActiveByDefault =
                "App.UserManagement.IsNewRegisteredUserActiveByDefault";

            public const string UseCaptchaOnRegistration = "App.UserManagement.UseCaptchaOnRegistration";
            public const string SmsVerificationEnabled = "App.UserManagement.SmsVerificationEnabled";
        }

        public static class SMSManagement
        {
            public const string AppKey = "App.SMSManagement.AppKey";
            public const string AppSecret = "App.SMSManagement.AppSecret";
            public const string SignName = "App.SMSManagement.SignName";
            public const string UserIdentityValidateTemplateCode = "App.SMSManagement.UserIdentityValidateTemplateCode";
            public const string UserLoginConfirmTemplateCode = "App.SMSManagement.UserLoginConfirmTemplateCode";
            public const string UserLoginErrorTemplateCode = "App.SMSManagement.UserLoginErrorTemplateCode";
            public const string UserRegisterTemplateCode = "App.SMSManagement.UserRegisterTemplateCode";
            public const string UserChangePasswordTemplateCode = "App.SMSManagement.UserChangePasswordTemplateCode";
            public const string UserChangeInformationTemplateCode = "App.SMSManagement.UserChangeInformationTemplateCode";
        }
        
        public static class WechatManagement
        {
            public const string AppKey = "App.WechatManagement.AppKey";
            public const string AppSecret = "App.WechatManagement.AppSecret";
        }
        
        public static class JinseManagement
        {
            public const string AccessKey = "62d123757c01fd3818e4250a9b7402e1";
            public const string SecretKey = "3773b2d9cc1584ee";
        }

        public static class Recaptcha
        {
            public const string SiteKey = "Recaptcha.SiteKey";
        }

        public static class CacheKeys
        {
            public const string TenantRegistrationCache = "TenantRegistrationCache";
        }
    }
}