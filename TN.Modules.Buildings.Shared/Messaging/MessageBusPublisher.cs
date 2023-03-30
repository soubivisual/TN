using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using System.Reflection;
using System.Text;
using System.Text.Json;
using TN.Modules.Buildings.Shared.Events;
using TN.Modules.Buildings.Shared.Persistance;

namespace TN.Modules.Buildings.Shared.Messaging
{
    internal sealed class MessageBusPublisher : IMessageBusPublisher
    {
        private readonly ILogger<MessageBusPublisher> _logger;

        private readonly IConnection _connection;
        private readonly IModel _channel;

        private const string ExchangeName = "TNExchange";
        private const string RoutingKey = "";

        private static readonly string QueueName = Assembly.GetEntryAssembly().GetName().Name;

        public MessageBusPublisher(IConfiguration configuration, ILogger<MessageBusPublisher> logger)
        {
            _logger = logger;

            try
            {
                var factory = new ConnectionFactory();
                factory.Uri = new Uri(configuration.GetConnectionString(ConnectionStrings.EventBus));
                factory.ClientProvidedName = $"{Assembly.GetEntryAssembly().GetName().Name}_{Guid.NewGuid()}";

                _connection = factory.CreateConnection();
                _connection.ConnectionShutdown += RabbitMQ_ConnectionShutdown;

                _channel = _connection.CreateModel();
                _channel.ExchangeDeclare(exchange: ExchangeName, type: ExchangeType.Fanout);
                _channel.QueueDeclare(queue: QueueName, durable: false, exclusive: false, autoDelete: false, arguments: null);
                _channel.QueueBind(queue: QueueName, exchange: ExchangeName, routingKey: RoutingKey, arguments: null);

                _logger.LogInformation("Connected to MessageBus");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Could not connect to the Message Bus: {ex.Message}");
            }
        }

        public void Publish<T>(T data)
        {
            var payload = new EventBase(data.GetType().AssemblyQualifiedName, JsonSerializer.Serialize(data));
            var message = JsonSerializer.Serialize(payload);
            var body = Encoding.UTF8.GetBytes(message);
            var basicProperties = _channel.CreateBasicProperties();
            basicProperties.Persistent = true;

            _channel.BasicPublish(exchange: ExchangeName, routingKey: RoutingKey, basicProperties: basicProperties, body: body);

            _logger.LogInformation($"We have sent {message}");
        }

        public void Dispose()
        {
            _logger.LogInformation($"{nameof(MessageBusPublisher)} Disposed");

            if (_channel.IsOpen)
            {
                _channel.Close();
                _connection.Close();
            }
        }

        private void RabbitMQ_ConnectionShutdown(object sender, ShutdownEventArgs e)
        {
            _logger.LogInformation($"{nameof(MessageBusPublisher)} Connection Shutdown");
        }
    }
}
