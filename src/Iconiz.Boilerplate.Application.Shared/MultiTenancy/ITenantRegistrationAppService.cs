using System.Threading.Tasks;
using Abp.Application.Services;
using Iconiz.Boilerplate.Editions.Dto;
using Iconiz.Boilerplate.MultiTenancy.Dto;

namespace Iconiz.Boilerplate.MultiTenancy
{
    public interface ITenantRegistrationAppService: IApplicationService
    {
        Task<RegisterTenantOutput> RegisterTenant(RegisterTenantInput input);

        Task<EditionsSelectOutput> GetEditionsForSelect();

        Task<EditionSelectDto> GetEdition(int editionId);
    }
}