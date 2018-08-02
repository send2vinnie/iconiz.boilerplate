using Abp.Notifications;
using Iconiz.Boilerplate.Dto;

namespace Iconiz.Boilerplate.Notifications.Dto
{
    public class GetUserNotificationsInput : PagedInputDto
    {
        public UserNotificationState? State { get; set; }
    }
}