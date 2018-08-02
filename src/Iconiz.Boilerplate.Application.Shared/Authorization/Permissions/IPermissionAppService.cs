using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Iconiz.Boilerplate.Authorization.Permissions.Dto;

namespace Iconiz.Boilerplate.Authorization.Permissions
{
    public interface IPermissionAppService : IApplicationService
    {
        ListResultDto<FlatPermissionWithLevelDto> GetAllPermissions();
    }
}
