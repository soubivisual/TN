using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace TN.Modules.Buildings.Shared.Events
{
    public sealed class EventDispatcher : IEventDispatcher
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<EventDispatcher> _logger;

        public EventDispatcher(IServiceProvider serviceProvider, ILogger<EventDispatcher> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        public async Task<bool> PublishAsync<TEvent>(TEvent @event, CancellationToken cancellationToken = default)
            where TEvent : class, IEvent
        {
            try
            {
                using var scope = _serviceProvider.CreateScope();
                var handlerType = typeof(IEventHandler<>).MakeGenericType(@event.GetType());
                var handlers = scope.ServiceProvider.GetServices(handlerType);
                var method = handlerType.GetMethod(nameof(IEventHandler<IEvent>.Handle));
                
                if (method is null)
                {
                    throw new InvalidOperationException($"Event handler for '{@event.GetType().Name}' is invalid.");
                }

                var tasks = handlers.Select(x => (Task)method.Invoke(x, new object[] { @event, cancellationToken }));
                await Task.WhenAll(tasks);
                return true;
            }
            catch(Exception ex)
            {
                _logger.LogError($"Error al despachar el evento {@event.GetType().Name}: {ex.Message}");
                return false;
            }
        }
    }
}
