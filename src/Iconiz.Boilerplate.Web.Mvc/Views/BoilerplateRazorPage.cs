using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace Iconiz.Boilerplate.Web.Views
{
    public abstract class BoilerplateRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected BoilerplateRazorPage()
        {
            LocalizationSourceName = BoilerplateConsts.LocalizationSourceName;
        }
    }
}
