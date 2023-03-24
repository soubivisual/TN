using MediatR;

namespace TN.Modules.Buildings.Shared.Events
{
    public interface IEventHandler<in TEvent> : INotificationHandler<TEvent> where TEvent : IEvent
        //<in TEvent> where TEvent : class, IEvent
    {
        new Task Handle(TEvent @event, CancellationToken cancellationToken = default);
    }
}
