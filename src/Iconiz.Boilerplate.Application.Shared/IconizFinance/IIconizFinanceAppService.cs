using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Iconiz.Boilerplate.IconizFinance.Dto;

namespace Iconiz.Boilerplate.IconizFinance
{
    public interface IIconizFinanceAppService : IApplicationService
    {
        Task<PagedResultDto<GetIconizTopicOutput>> GetJinseTopic(GetIconizTopicInput input);
        Task<JinseLiveOutput> GetJinseLive();
        Task<IconizTopicOneDto> GetOneJinseTopic(int id);
    }
}