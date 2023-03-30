namespace TN.Modules.Buildings.Shared.Events
{
    public interface IEventDispatcher
    {
        Task<bool> PublishAsync<TEvent>(TEvent @event, CancellationToken cancellationToken = default)
            where TEvent : class, IEvent;
    }
}
