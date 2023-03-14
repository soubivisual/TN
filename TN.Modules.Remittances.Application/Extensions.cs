using Microsoft.Extensions.DependencyInjection;
using TN.Modules.Buildings.Application;
using TN.Modules.Buildings.Shared.Mapping;

namespace TN.Modules.Remittances.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            services.AddMediator(typeof(Extensions));
            services.AddMappings(typeof(Extensions));

            return services;
        }
    }
}
