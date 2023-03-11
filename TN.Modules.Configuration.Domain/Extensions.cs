using Microsoft.Extensions.DependencyInjection;

namespace TN.Modules.Configuration.Domain
{
    public static class Extensions
    {
        public static IServiceCollection AddDomainLayer(this IServiceCollection services)
        {
            return services;
        }
    }
}
