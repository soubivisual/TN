using TN.Modules.Buildings.Application.Configuration;
using TN.Modules.Buildings.Shared.Mapping;
using TN.Modules.Notifications.Domain.Notifications.Repositories;

namespace TN.Modules.Notifications.Application.Notifications.Queries.GetNotification
{
    internal class GetNotificationQueryHandler : IQueryHandler<GetNotificationQuery, NotificationDto>
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly IMapping _mapping;

        public GetNotificationQueryHandler(INotificationRepository notificationRepository, IMapping mapping)
        {
            _notificationRepository = notificationRepository;
            _mapping = mapping;
        }

        public async Task<NotificationDto> Handle(GetNotificationQuery request, CancellationToken cancellationToken)
        {
            var notification = await _notificationRepository.GetAsync(request.NotificationId);
            return _mapping.Map<NotificationDto>(notification);
        }
    }
}
