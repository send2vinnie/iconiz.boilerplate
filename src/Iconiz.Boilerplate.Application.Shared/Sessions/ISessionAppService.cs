using System.Threading.Tasks;
using Abp.Application.Services;
using Iconiz.Boilerplate.Sessions.Dto;

namespace Iconiz.Boilerplate.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();

        Task<UpdateUserSignInTokenOutput> UpdateUserSignInToken();
    }
}
