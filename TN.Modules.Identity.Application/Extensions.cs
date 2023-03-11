using Microsoft.Extensions.DependencyInjection;
using TN.Modules.Building.Application;
using TN.Modules.Building.Shared.Mapping;

namespace TN.Modules.Identity.Application
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
