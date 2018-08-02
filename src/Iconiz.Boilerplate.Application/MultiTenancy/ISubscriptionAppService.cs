using System.Threading.Tasks;
using Abp.Application.Services;

namespace Iconiz.Boilerplate.MultiTenancy
{
    public interface ISubscriptionAppService : IApplicationService
    {
        Task UpgradeTenantToEquivalentEdition(int upgradeEditionId);
    }
}
