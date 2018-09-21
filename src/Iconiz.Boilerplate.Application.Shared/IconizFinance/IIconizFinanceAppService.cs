using System.Threading.Tasks;
using Abp.Application.Services;
using Iconiz.Boilerplate.IconizFinance.Dto;

namespace Iconiz.Boilerplate.IconizFinance
{
    public interface IIconizFinanceAppService : IApplicationService
    {
        Task<JinseTopicListOutput[]> GetJinseTopic(string last_id = null);
        Task<JinseLiveOutput> GetJinseLive();
    }
}