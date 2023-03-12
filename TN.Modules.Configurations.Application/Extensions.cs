using Microsoft.Extensions.DependencyInjection;
using TN.Modules.Buildings.Application;

namespace TN.Modules.Configurations.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            services.AddMediator(typeof(Extensions));

            return services;
        }
    }
}
