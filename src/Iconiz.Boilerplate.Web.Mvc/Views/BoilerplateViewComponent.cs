using Abp.AspNetCore.Mvc.ViewComponents;

namespace Iconiz.Boilerplate.Web.Views
{
    public abstract class BoilerplateViewComponent : AbpViewComponent
    {
        protected BoilerplateViewComponent()
        {
            LocalizationSourceName = BoilerplateConsts.LocalizationSourceName;
        }
    }
}