using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using TN.Modules.Buildings.Shared.Persistance;
using TN.Modules.Buildings.Shared.Events;

namespace TN.Modules.Buildings.Shared.Messaging
{
    internal sealed class MessageBusSubscriber : BackgroundService
    {
        private readonly IEventDispatcher _eventDispatcher;
        private readonly ILogger<MessageBusSubscriber> _logger;

        private readonly IConnection _connection;
        private readonly IModel _channel;

        private const string ExchangeName = "TNExchange";
        private const string RoutingKey = "";
        private const string QueueName = "TNQueue";

        public MessageBusSubscriber(IConfiguration configuration, ILogger<MessageBusSubscriber> logger, IEventDispatcher eventDispatcher)
        {
            _logger = logger;
            _eventDispatcher = eventDispatcher;

            try
            {
                var factory = new ConnectionFactory();
                factory.Uri = new Uri(configuration.GetConnectionString(ConnectionStrings.EventBus));
                factory.ClientProvidedName = Assembly.GetEntryAssembly().GetName().Name;

                _connection = factory.CreateConnection();
                _channel = _connection.CreateModel();
                _channel.ExchangeDeclare(exchange: ExchangeName, type: ExchangeType.Fanout);
                _channel.QueueDeclare(queue: QueueName, durable: false, exclusive: false, autoDelete: false, arguments: null);
                _channel.QueueBind(queue: QueueName, exchange: ExchangeName, routingKey: RoutingKey, arguments: null);
                _channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);
                _connection.ConnectionShutdown += RabbitMQ_ConnectionShutdown;

                _logger.LogInformation("--> Listenting on the Message Bus...");
            }
            catch (Exception ex)
            {
                _logger.LogError($"--> Could not connect to the Message Bus: {ex.Message}");
            }
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += async (ch, ea) =>
            {
                _logger.LogInformation("--> Event Received!");

                var message = Encoding.UTF8.GetString(ea.Body.ToArray());
                var payload = JsonSerializer.Deserialize<EventBase>(message);
                var type = Type.GetType(payload.Event);

                if (type == null)
                    return;

                using MemoryStream stream = new(Encoding.UTF8.GetBytes(payload.Data));
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var @event = (IEvent)JsonSerializer.Deserialize(stream, type, options);

                await _eventDispatcher.PublishAsync(@event, stoppingToken);

                _channel.BasicAck(ea.DeliveryTag, multiple: false);
            };

            var consumerTag = _channel.BasicConsume(queue: QueueName, autoAck: false, consumer: consumer);
            //_channel.BasicCancel(consumerTag);

            return Task.CompletedTask;
        }

        public override void Dispose()
        {
            _logger.LogInformation($"{nameof(MessageBusSubscriber)} Disposed");

            if (_channel.IsOpen)
            {
                _channel.Close();
                _connection.Close();
            }

            base.Dispose();
        }

        private void RabbitMQ_ConnectionShutdown(object sender, ShutdownEventArgs e)
        {
            _logger.LogInformation("--> Connection Shutdown");
        }
    }
}
