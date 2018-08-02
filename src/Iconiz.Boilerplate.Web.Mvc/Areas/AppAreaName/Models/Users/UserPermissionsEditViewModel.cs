using Abp.AutoMapper;
using Iconiz.Boilerplate.Authorization.Users;
using Iconiz.Boilerplate.Authorization.Users.Dto;
using Iconiz.Boilerplate.Web.Areas.AppAreaName.Models.Common;

namespace Iconiz.Boilerplate.Web.Areas.AppAreaName.Models.Users
{
    [AutoMapFrom(typeof(GetUserPermissionsForEditOutput))]
    public class UserPermissionsEditViewModel : GetUserPermissionsForEditOutput, IPermissionsEditViewModel
    {
        public User User { get; private set; }

        public UserPermissionsEditViewModel(GetUserPermissionsForEditOutput output, User user)
        {
            User = user;
            output.MapTo(this);
        }
    }
}