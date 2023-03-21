namespace TN.Modules.Buildings.API.Messaging
{
    public interface IMessageBusClient
    {
        void Publish<T>(T data);
    }
}
