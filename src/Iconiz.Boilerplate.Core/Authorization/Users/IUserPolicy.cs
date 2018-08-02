using System.Threading.Tasks;
using Abp.Domain.Policies;

namespace Iconiz.Boilerplate.Authorization.Users
{
    public interface IUserPolicy : IPolicy
    {
        Task CheckMaxUserCountAsync(int tenantId);
    }
}
