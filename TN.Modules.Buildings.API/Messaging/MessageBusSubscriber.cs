using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;
using TN.Modules.Buildings.Application;
using TN.Modules.Buildings.API.Events;

namespace TN.Modules.Buildings.API.Messaging
{
    internal sealed class MessageBusSubscriber : BackgroundService
    {
        private readonly IEventDispatcher _eventDispatcher;
        private readonly ILogger<MessageBusSubscriber> _logger;

        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly string _queueName;

        public MessageBusSubscriber(IEventDispatcher eventDispatcher, ILogger<MessageBusSubscriber> logger)
        {
            _eventDispatcher = eventDispatcher;
            _logger = logger;

            var factory = new ConnectionFactory() { HostName = "localhost", Port = 5672 };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.ExchangeDeclare(exchange: "trigger", type: ExchangeType.Fanout);
            _queueName = _channel.QueueDeclare().QueueName;
            _channel.QueueBind(queue: _queueName, exchange: "trigger", routingKey: "");

            _logger.LogInformation("--> Listenting on the Message Bus...");

            _connection.ConnectionShutdown += RabbitMQ_ConnectionShutdown;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += (ch, ea) =>
            {
                _logger.LogInformation("--> Event Received!");

                var notificationMessage = Encoding.UTF8.GetString(ea.Body.ToArray());
                var payload = JsonSerializer.Deserialize<EventBase>(notificationMessage);
                var type = Type.GetType(payload.Event);

                if (type == null)
                    return;

                //var @event = Activator.CreateInstance(type, parameters) as IEvent;
                using MemoryStream stream = new(Encoding.UTF8.GetBytes(payload.Data));
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var @event = (IEvent)JsonSerializer.Deserialize(stream, type, options);

                //_channel.BasicAck(ea.DeliveryTag, false);

                _eventDispatcher.PublishAsync(@event, stoppingToken);
            };

            _channel.BasicConsume(queue: _queueName, autoAck: true, consumer: consumer);

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
