using Abp.Domain.Services;

namespace Iconiz.Boilerplate
{
    public abstract class BoilerplateDomainServiceBase : DomainService
    {
        /* Add your common members for all your domain services. */

        protected BoilerplateDomainServiceBase()
        {
            LocalizationSourceName = BoilerplateConsts.LocalizationSourceName;
        }
    }
}
