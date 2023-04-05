using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using TN.Modules.Buildings.Shared.Mapper;
using TN.Modules.Buildings.Shared.Validator;
using TN.Modules.Remittances.Application;
using TN.Modules.Remittances.Domain;
using TN.Modules.Remittances.Infrastructure;

namespace TN.Modules.Remittances.API
{
    public static class Extensions
    {
        public static IServiceCollection AddRemittancesModule(this IServiceCollection services)
        {
            services.AddDomainLayer();
            services.AddApplicationLayer();
            services.AddInfrastructureLayer();

            services.AddValidators(typeof(Extensions));
            services.AddMappings(typeof(Extensions));

            return services;
        }

        public static IApplicationBuilder UseRemittancesModule(this IApplicationBuilder app)
        {
            return app;
        }
    }
}
