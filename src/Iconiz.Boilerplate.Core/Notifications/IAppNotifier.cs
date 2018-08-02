using System.Threading.Tasks;
using Abp;
using Abp.Notifications;
using Iconiz.Boilerplate.Authorization.Users;
using Iconiz.Boilerplate.MultiTenancy;

namespace Iconiz.Boilerplate.Notifications
{
    public interface IAppNotifier
    {
        Task WelcomeToTheApplicationAsync(User user);

        Task NewUserRegisteredAsync(User user);

        Task NewTenantRegisteredAsync(Tenant tenant);

        Task SendMessageAsync(UserIdentifier user, string message, NotificationSeverity severity = NotificationSeverity.Info);
    }
}
