using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.DependencyInjection;

namespace TN.Modules.Buildings.Shared.HealthChecks
{
    public static class Extensions
    {
        public static IServiceCollection AddModulesHealthChecks(this IServiceCollection services)
        {
            services.AddHealthChecks()
                .AddCheck<SelfHealthCheck>(nameof(SelfHealthCheck))
                .AddCheck<DatabaseHealthCheck>(nameof(DatabaseHealthCheck))
                .AddCheck<CacheHealthCheck>(nameof(CacheHealthCheck))
                .AddCheck<MessageBusHealthCheck>(nameof(MessageBusHealthCheck));

            services.AddHealthChecks();

            return services;
        }

        public static IApplicationBuilder UseModulesHealthChecks(this IApplicationBuilder app)
        {
            app.UseHealthChecks("/health", new HealthCheckOptions
            {
                Predicate = _ => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });

            return app;
        }
    }
}
