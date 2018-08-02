using Abp.Configuration;
using Abp.Net.Mail;
using Abp.Net.Mail.Smtp;
using Abp.Runtime.Security;

namespace Iconiz.Boilerplate.Emailing
{
    public class BoilerplateSmtpEmailSenderConfiguration : SmtpEmailSenderConfiguration
    {
        public BoilerplateSmtpEmailSenderConfiguration(ISettingManager settingManager) : base(settingManager)
        {

        }

        public override string Password => SimpleStringCipher.Instance.Decrypt(GetNotEmptySettingValue(EmailSettingNames.Smtp.Password));
    }
}