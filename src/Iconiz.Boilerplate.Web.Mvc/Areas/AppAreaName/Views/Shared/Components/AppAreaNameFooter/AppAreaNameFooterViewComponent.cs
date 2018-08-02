using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Iconiz.Boilerplate.Web.Areas.AppAreaName.Models.Layout;
using Iconiz.Boilerplate.Web.Session;
using Iconiz.Boilerplate.Web.Views;

namespace Iconiz.Boilerplate.Web.Areas.AppAreaName.Views.Shared.Components.AppAreaNameFooter
{
    public class AppAreaNameFooterViewComponent : BoilerplateViewComponent
    {
        private readonly IPerRequestSessionCache _sessionCache;

        public AppAreaNameFooterViewComponent(IPerRequestSessionCache sessionCache)
        {
            _sessionCache = sessionCache;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var footerModel = new FooterViewModel
            {
                LoginInformations = await _sessionCache.GetCurrentLoginInformationsAsync()
            };

            return View(footerModel);
        }
    }
}
