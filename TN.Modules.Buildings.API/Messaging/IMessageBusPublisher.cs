namespace TN.Modules.Buildings.API.Messaging
{
    public interface IMessageBusPublisher
    {
        void Publish<T>(T data);
    }
}
