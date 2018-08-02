using System.Threading.Tasks;
using Abp.Application.Services;
using Iconiz.Boilerplate.Configuration.Host.Dto;

namespace Iconiz.Boilerplate.Configuration.Host
{
    public interface IHostSettingsAppService : IApplicationService
    {
        Task<HostSettingsEditDto> GetAllSettings();

        Task UpdateAllSettings(HostSettingsEditDto input);

        Task SendTestEmail(SendTestEmailInput input);
    }
}
