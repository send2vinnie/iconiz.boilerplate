using System.Threading.Tasks;
using Abp.Application.Services;
using Iconiz.Boilerplate.Install.Dto;

namespace Iconiz.Boilerplate.Install
{
    public interface IInstallAppService : IApplicationService
    {
        Task Setup(InstallDto input);

        AppSettingsJsonDto GetAppSettingsJson();

        CheckDatabaseOutput CheckDatabase();
    }
}