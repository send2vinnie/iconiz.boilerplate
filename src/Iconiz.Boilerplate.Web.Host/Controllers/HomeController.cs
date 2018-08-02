using Abp.Auditing;
using Microsoft.AspNetCore.Mvc;

namespace Iconiz.Boilerplate.Web.Controllers
{
    public class HomeController : BoilerplateControllerBase
    {
        [DisableAuditing]
        public IActionResult Index()
        {
            return Redirect("/swagger");
        }
    }
}
