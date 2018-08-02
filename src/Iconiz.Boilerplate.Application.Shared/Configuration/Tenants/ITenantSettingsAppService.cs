using System.Threading.Tasks;
using Abp.Application.Services;
using Iconiz.Boilerplate.Configuration.Tenants.Dto;

namespace Iconiz.Boilerplate.Configuration.Tenants
{
    public interface ITenantSettingsAppService : IApplicationService
    {
        Task<TenantSettingsEditDto> GetAllSettings();

        Task UpdateAllSettings(TenantSettingsEditDto input);

        Task ClearLogo();

        Task ClearCustomCss();
    }
}
