using System.Collections.Generic;
using Iconiz.Boilerplate.Authorization.Permissions.Dto;

namespace Iconiz.Boilerplate.Web.Areas.AppAreaName.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }

        List<string> GrantedPermissionNames { get; set; }
    }
}