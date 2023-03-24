namespace TN.Modules.Buildings.Shared.Messaging
{
    public interface IMessageBusPublisher
    {
        void Publish<T>(T data);
    }
}
