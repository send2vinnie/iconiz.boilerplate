using Abp.Application.Services;
using Iconiz.Boilerplate.Dto;
using Iconiz.Boilerplate.Logging.Dto;

namespace Iconiz.Boilerplate.Logging
{
    public interface IWebLogAppService : IApplicationService
    {
        GetLatestWebLogsOutput GetLatestWebLogs();

        FileDto DownloadWebLogs();
    }
}
