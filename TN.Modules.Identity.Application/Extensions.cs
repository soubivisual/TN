using Microsoft.Extensions.DependencyInjection;
using TN.Modules.Building.Application;

namespace TN.Modules.Identity.Application
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
