using System.Collections.Generic;
using Iconiz.Boilerplate.Authorization.Permissions.Dto;

namespace Iconiz.Boilerplate.Authorization.Users.Dto
{
    public class GetUserPermissionsForEditOutput
    {
        public List<FlatPermissionDto> Permissions { get; set; }

        public List<string> GrantedPermissionNames { get; set; }
    }
}