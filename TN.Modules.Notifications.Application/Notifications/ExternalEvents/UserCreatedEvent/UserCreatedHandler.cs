using Microsoft.Extensions.Logging;
using TN.Modules.Buildings.Application.Configuration;
using TN.Modules.Identities.Shared.Events;
using TN.Modules.Notifications.Domain.Notifications.Entities;
using TN.Modules.Notifications.Domain.Notifications.Repositories;
using TN.Shared.Utils.Misc.Time;

namespace TN.Modules.Notifications.Application.Notifications.ExternalEvents.UserCreatedHandler
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
