using Abp.AutoMapper;
using Iconiz.Boilerplate.MultiTenancy.Dto;

namespace Iconiz.Boilerplate.Web.Models.TenantRegistration
{
    [AutoMapFrom(typeof(RegisterTenantOutput))]
    public class TenantRegisterResultViewModel : RegisterTenantOutput
    {
        public string TenantLoginAddress { get; set; }
    }
}