using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Iconiz.Boilerplate.Web.Session;

namespace Iconiz.Boilerplate.Web.Views.Shared.Components.AccountLogo
{
    public class AccountLogoViewComponent : BoilerplateViewComponent
    {
        private readonly IPerRequestSessionCache _sessionCache;

        public AccountLogoViewComponent(IPerRequestSessionCache sessionCache)
        {
            _sessionCache = sessionCache;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var loginInfo = await _sessionCache.GetCurrentLoginInformationsAsync();
            return View(new AccountLogoViewModel(loginInfo));
        }
    }
}
