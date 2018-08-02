using Microsoft.AspNetCore.Mvc;
using Iconiz.Boilerplate.Web.Controllers;

namespace Iconiz.Boilerplate.Web.Public.Controllers
{
    public class HomeController : BoilerplateControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}