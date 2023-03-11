using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using TN.Modules.Configuration.Application;
using TN.Modules.Configuration.Domain;
using TN.Modules.Configuration.Infrastructure;

namespace TN.Modules.Configuration.API
{
    public static class Extensions
    {
        public static IServiceCollection AddConfigurationModule(this IServiceCollection services)
        {
            services.AddDomainLayer();
            services.AddApplicationLayer();
            services.AddInfrastructureLayer();

            return services;
        }

        public static IApplicationBuilder UseConfigurationModule(this IApplicationBuilder app)
        {
            return app;
        }
    }
}
