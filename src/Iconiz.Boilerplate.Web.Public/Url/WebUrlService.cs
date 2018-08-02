using Abp.Dependency;
using Iconiz.Boilerplate.Configuration;
using Iconiz.Boilerplate.Url;
using Iconiz.Boilerplate.Web.Url;

namespace Iconiz.Boilerplate.Web.Public.Url
{
    public class WebUrlService : WebUrlServiceBase, IWebUrlService, ITransientDependency
    {
        public WebUrlService(
            IAppConfigurationAccessor appConfigurationAccessor) :
            base(appConfigurationAccessor)
        {
        }

        public override string WebSiteRootAddressFormatKey => "App:WebSiteRootAddress";

        public override string ServerRootAddressFormatKey => "App:AdminWebSiteRootAddress";
    }
}