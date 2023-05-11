using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using TN.Modules.Buildings.Shared.Persistance.Caching;

namespace TN.Modules.Buildings.Shared.HealthChecks
{
    internal class CacheHealthCheck : IHealthCheck
    {
        private readonly IDistributedCache _cache;

        public CacheHealthCheck(IDistributedCache cache)
        {
            _cache = cache;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            try
            {
                await _cache.GetRecord<string>("Health");

                return HealthCheckResult.Healthy();
            }
            catch (Exception ex)
            {
                return HealthCheckResult.Unhealthy(exception: ex);
            }
        }
    }
}
