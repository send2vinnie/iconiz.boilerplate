﻿using Microsoft.AspNetCore.Antiforgery;

namespace Iconiz.Boilerplate.Web.Controllers
{
    public class AntiForgeryController : BoilerplateControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
