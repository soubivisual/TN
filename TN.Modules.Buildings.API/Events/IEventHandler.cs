using MediatR;
using TN.Modules.Buildings.Application;

namespace TN.Modules.Buildings.API.Events
{
    public interface IEventHandler<in TEvent> : INotificationHandler<TEvent> where TEvent : IEvent
        //<in TEvent> where TEvent : class, IEvent
    {
        new Task Handle(TEvent @event, CancellationToken cancellationToken = default);
    }
}
