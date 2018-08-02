using System.Threading.Tasks;
using Iconiz.Boilerplate.Security.Recaptcha;

namespace Iconiz.Boilerplate.Tests.Web
{
    public class FakeRecaptchaValidator : IRecaptchaValidator
    {
        public Task ValidateAsync(string captchaResponse)
        {
            return Task.CompletedTask;
        }
    }
}
