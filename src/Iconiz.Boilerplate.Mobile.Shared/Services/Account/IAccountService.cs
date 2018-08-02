using System.Threading.Tasks;
using Iconiz.Boilerplate.ApiClient.Models;

namespace Iconiz.Boilerplate.Services.Account
{
    public interface IAccountService
    {
        AbpAuthenticateModel AbpAuthenticateModel { get; set; }
        AbpAuthenticateResultModel AuthenticateResultModel { get; set; }
        Task LoginUserAsync();
    }
}
