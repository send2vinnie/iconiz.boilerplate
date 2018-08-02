using Abp.AutoMapper;
using Iconiz.Boilerplate.MultiTenancy.Dto;

namespace Iconiz.Boilerplate.Web.Models.TenantRegistration
{
    [AutoMapFrom(typeof(EditionsSelectOutput))]
    public class EditionsSelectViewModel : EditionsSelectOutput
    {
        public EditionsSelectViewModel(EditionsSelectOutput output)
        {
            output.MapTo(this);
        }
    }
}
