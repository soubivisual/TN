using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using RabbitMQ.Client;
using System.Reflection;
using System.Threading.Channels;
using TN.Modules.Buildings.Shared.Messaging;
using TN.Modules.Buildings.Shared.Persistance;

namespace TN.Modules.Buildings.Shared.HealthChecks
{
    internal class MessageBusHealthCheck : IHealthCheck
    {
        private readonly IConfiguration _configuration;

        public MessageBusHealthCheck(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            try
            {
                var factory = new ConnectionFactory();
                factory.Uri = new Uri(_configuration.GetConnectionString(ConnectionStrings.EventBus));

                var _connection = factory.CreateConnection();
                var channel = _connection.CreateModel();

                return Task.FromResult(HealthCheckResult.Healthy());
            }
            catch (Exception ex)
            {
                return Task.FromResult(HealthCheckResult.Unhealthy(exception: ex));
            }
        }
    }
}
