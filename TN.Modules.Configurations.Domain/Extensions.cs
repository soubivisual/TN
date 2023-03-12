using Microsoft.Extensions.DependencyInjection;

namespace TN.Modules.Configurations.Domain
{
    public static class Extensions
    {
        public static IServiceCollection AddDomainLayer(this IServiceCollection services)
        {
            return services;
        }
    }
}
