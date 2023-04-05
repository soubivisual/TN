using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using TN.Modules.Buildings.Shared.Mapper;
using TN.Modules.Buildings.Shared.Validator;
using TN.Modules.Loggers.Application;
using TN.Modules.Loggers.Domain;
using TN.Modules.Loggers.Infrastructure;

namespace TN.Modules.Loggers.API
{
    public static class Extensions
    {
        public static IServiceCollection AddLoggersModule(this IServiceCollection services)
        {
            services.AddDomainLayer();
            services.AddApplicationLayer();
            services.AddInfrastructureLayer();

            services.AddValidators(typeof(Extensions));
            services.AddMappings(typeof(Extensions));

            return services;
        }

        public static IApplicationBuilder UseLoggersModule(this IApplicationBuilder app)
        {
            return app;
        }
    }
}
