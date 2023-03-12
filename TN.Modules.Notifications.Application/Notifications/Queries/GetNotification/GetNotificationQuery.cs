using TN.Modules.Buildings.Application.Contracts;

namespace TN.Modules.Notifications.Application.Notifications.Queries.GetNotification
{
    public sealed record GetNotificationQuery(long NotificationId) : IQuery<NotificationDto>
    {

    }
}
