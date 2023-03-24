using Microsoft.Extensions.DependencyInjection;

namespace TN.Modules.Buildings.Shared.Events
{
    public sealed class EventDispatcher : IEventDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public EventDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task PublishAsync<TEvent>(TEvent @event, CancellationToken cancellationToken = default)
            where TEvent : class, IEvent
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
        }
    }
}
