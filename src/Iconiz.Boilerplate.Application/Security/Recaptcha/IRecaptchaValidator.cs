using System.Threading.Tasks;

namespace Iconiz.Boilerplate.Security.Recaptcha
{
    public interface IRecaptchaValidator
    {
        Task ValidateAsync(string captchaResponse);
    }
}