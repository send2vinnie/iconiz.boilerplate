using Abp.AutoMapper;
using Iconiz.Boilerplate.MultiTenancy;
using Iconiz.Boilerplate.MultiTenancy.Dto;
using Iconiz.Boilerplate.Web.Areas.AppAreaName.Models.Common;

namespace Iconiz.Boilerplate.Web.Areas.AppAreaName.Models.Tenants
{
    [AutoMapFrom(typeof (GetTenantFeaturesEditOutput))]
    public class TenantFeaturesEditViewModel : GetTenantFeaturesEditOutput, IFeatureEditViewModel
    {
        public Tenant Tenant { get; set; }

        public TenantFeaturesEditViewModel(Tenant tenant, GetTenantFeaturesEditOutput output)
        {
            Tenant = tenant;
            output.MapTo(this);
        }
    }
}