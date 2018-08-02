using Abp.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;
using Iconiz.Boilerplate.Authorization;
using Iconiz.Boilerplate.Web.Controllers;

namespace Iconiz.Boilerplate.Web.Areas.AppAreaName.Controllers
{
    [Area("AppAreaName")]
    [AbpMvcAuthorize(AppPermissions.Pages_Tenant_Dashboard)]
    public class DashboardController : BoilerplateControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}