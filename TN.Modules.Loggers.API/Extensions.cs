using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using TN.Modules.Loggers.Application;
using TN.Modules.Loggers.Domain;
using TN.Modules.Loggers.Infrastructure;

namespace TN.Modules.Loggers.API
{
    public static class Extensions
    {
        public static IServiceCollection AddLoggerModule(this IServiceCollection services)
        {
            services.AddDomainLayer();
            services.AddApplicationLayer();
            services.AddInfrastructureLayer();

            return services;
        }

        public static IApplicationBuilder UseLoggerModule(this IApplicationBuilder app)
        {
            return app;
        }
    }
}
