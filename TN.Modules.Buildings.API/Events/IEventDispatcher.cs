using TN.Modules.Buildings.Application;

namespace TN.Modules.Buildings.API.Events
{
    public interface IEventDispatcher
    {
        Task PublishAsync<TEvent>(TEvent @event, CancellationToken cancellationToken = default)
            where TEvent : class, IEvent;
    }
}
