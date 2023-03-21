using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;
using TN.Modules.Buildings.API.Events;

namespace TN.Modules.Buildings.API.Messaging
{
    internal sealed class MessageBusClient : IMessageBusClient
    {
        private readonly ILogger<MessageBusClient> _logger;

        private readonly IConnection _connection;
        private readonly IModel _channel;

        public MessageBusClient(ILogger<MessageBusClient> logger)
        {
            _logger = logger;

            var factory = new ConnectionFactory()
            {
                HostName = "localhost",
                Port = 5672
            };

            try
            {
                _connection = factory.CreateConnection();
                _channel = _connection.CreateModel();
                _channel.ExchangeDeclare(exchange: "trigger", type: ExchangeType.Fanout);
                _connection.ConnectionShutdown += RabbitMQ_ConnectionShutdown;

                _logger.LogInformation("--> Connected to MessageBus");
            }
            catch (Exception ex)
            {
                _logger.LogError($"--> Could not connect to the Message Bus: {ex.Message}");
            }
        }

        public void Publish<T>(T data)
        {
            var payload = new EventBase(data.GetType().AssemblyQualifiedName, JsonSerializer.Serialize(data));
            var message = JsonSerializer.Serialize(payload);
            var body = Encoding.UTF8.GetBytes(message);

            _channel.BasicPublish(exchange: "trigger", routingKey: "", basicProperties: null, body: body);

            _logger.LogInformation($"--> We have sent {message}");
        }

        public void Dispose()
        {
            _logger.LogInformation($"{nameof(MessageBusClient)} Disposed");

            if (_channel.IsOpen)
            {
                _channel.Close();
                _connection.Close();
            }
        }

        private void RabbitMQ_ConnectionShutdown(object sender, ShutdownEventArgs e)
        {
            _logger.LogInformation("--> RabbitMQ Connection Shutdown");
        }
    }
}
