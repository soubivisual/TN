using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using TN.Modules.Logger.Application;
using TN.Modules.Logger.Domain;
using TN.Modules.Logger.Infrastructure;

namespace TN.Modules.Logger.API
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
