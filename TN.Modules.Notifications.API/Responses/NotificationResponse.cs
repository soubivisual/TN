using TN.Modules.Buildings.Shared.Api;
using TN.Modules.Buildings.Shared.Dtos;

namespace TN.Modules.Notifications.API.Responses
{
    public class NotificationResponse : BaseResponse<NotificationDto>
    {
        public override NotificationDto Payload { get; init; }
    }
}
