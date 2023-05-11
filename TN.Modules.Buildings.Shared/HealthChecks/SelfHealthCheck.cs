using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace TN.Modules.Buildings.Shared.HealthChecks
{
    internal class SelfHealthCheck : IHealthCheck
    {
        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(HealthCheckResult.Healthy());
        }
    }
}
