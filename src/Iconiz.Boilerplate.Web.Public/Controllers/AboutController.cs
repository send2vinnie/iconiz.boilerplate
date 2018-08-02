using Microsoft.AspNetCore.Mvc;
using Iconiz.Boilerplate.Web.Controllers;

namespace Iconiz.Boilerplate.Web.Public.Controllers
{
    public class AboutController : BoilerplateControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}