using System.Threading.Tasks;
using Iconiz.Boilerplate.ApiClient.Models;

namespace Iconiz.Boilerplate.ApiClient
{
    public interface IAccessTokenManager
    {
        Task<string> GetAccessTokenAsync();
         
        Task<AbpAuthenticateResultModel> LoginAsync();

        void Logout();

        bool IsUserLoggedIn { get; }
    }
}