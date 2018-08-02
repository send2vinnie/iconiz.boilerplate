using Abp.AutoMapper;
using Iconiz.Boilerplate.Authorization.Roles.Dto;
using Iconiz.Boilerplate.Web.Areas.AppAreaName.Models.Common;

namespace Iconiz.Boilerplate.Web.Areas.AppAreaName.Models.Roles
{
    [AutoMapFrom(typeof(GetRoleForEditOutput))]
    public class CreateOrEditRoleModalViewModel : GetRoleForEditOutput, IPermissionsEditViewModel
    {
        public bool IsEditMode
        {
            get { return Role.Id.HasValue; }
        }

        public CreateOrEditRoleModalViewModel(GetRoleForEditOutput output)
        {
            output.MapTo(this);
        }
    }
}