using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Net.Mail;
using Iconiz.Boilerplate.Configuration.Host.Dto;

namespace Iconiz.Boilerplate.Configuration
{
    public abstract class SettingsAppServiceBase : BoilerplateAppServiceBase
    {
        private readonly IEmailSender _emailSender;

        protected SettingsAppServiceBase(
            IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        #region Send Test Email

        public async Task SendTestEmail(SendTestEmailInput input)
        {
            await _emailSender.SendAsync(
                input.EmailAddress,
                L("TestEmail_Subject"),
                L("TestEmail_Body")
            );
        }

        #endregion
    }
}
