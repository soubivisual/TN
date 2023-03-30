using TN.Modules.Buildings.Shared.Dtos;
using TN.Modules.Buildings.Shared.Queries;

namespace TN.Modules.Notifications.Application.Notifications.Queries.GetNotification
{
    public sealed record GetNotificationQuery(long NotificationId) : IQuery<NotificationDto>
    {

    }
}
