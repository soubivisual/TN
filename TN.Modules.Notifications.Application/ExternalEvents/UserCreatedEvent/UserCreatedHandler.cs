using Microsoft.Extensions.Logging;
using TN.Modules.Notifications.Domain.Notifications.Aggregates;
using TN.Modules.Notifications.Domain.Notifications.Repositories;
using TN.Modules.Buildings.Shared.Time;
using TN.Modules.Buildings.Shared.Events;
using TN.Modules.Buildings.Shared.Events.Identities;

namespace TN.Modules.Notifications.Application.ExternalEvents.UserCreatedHandler
{
    internal sealed class UserCreatedEventHandler : IEventHandler<UserCreatedEvent>
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly IClock _clock;
        private readonly ILogger<UserCreatedEventHandler> _logger;

        public UserCreatedEventHandler(INotificationRepository notificationRepository, IClock clock, ILogger<UserCreatedEventHandler> logger)
        {
            _notificationRepository = notificationRepository;
            _clock = clock;
            _logger = logger;
        }

        public async Task Handle(UserCreatedEvent @event, CancellationToken cancellationToken)
        {
            var notification = new Notification(
                default, 
                @event.TenantId, 
                @event.UserId, 
                Guid.NewGuid(), 
                Guid.NewGuid(), 
                1, 
                "Usuario Creado exitosamente", 
                "Se ha creado un usuario con este correo electrónico exitosamente", 
                "",
                false,
                _clock.CurrentDate(),
                null,
                null,
                Guid.NewGuid());

            await _notificationRepository.AddAsync(notification);

            _logger.LogInformation($"Created an owner for the user with ID: '{@event.UserId}'.");
        }
    }
}
