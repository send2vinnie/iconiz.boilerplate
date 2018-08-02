using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Iconiz.Boilerplate.Common.Dto;
using Iconiz.Boilerplate.Editions.Dto;

namespace Iconiz.Boilerplate.Common
{
    public interface ICommonLookupAppService : IApplicationService
    {
        Task<ListResultDto<SubscribableEditionComboboxItemDto>> GetEditionsForCombobox(bool onlyFreeItems = false);

        Task<PagedResultDto<NameValueDto>> FindUsers(FindUsersInput input);

        GetDefaultEditionNameOutput GetDefaultEditionName();
    }
}