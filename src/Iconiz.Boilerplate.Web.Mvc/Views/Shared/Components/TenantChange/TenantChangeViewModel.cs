using Abp.AutoMapper;
using Iconiz.Boilerplate.Sessions.Dto;

namespace Iconiz.Boilerplate.Web.Views.Shared.Components.TenantChange
{
    [AutoMapFrom(typeof(GetCurrentLoginInformationsOutput))]
    public class TenantChangeViewModel
    {
        public TenantLoginInfoDto Tenant { get; set; }
    }
}