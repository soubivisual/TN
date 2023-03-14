using Microsoft.Extensions.DependencyInjection;

namespace TN.Modules.Remittances.Domain
{
    public static class Extensions
    {
        public static IServiceCollection AddDomainLayer(this IServiceCollection services)
        {
            return services;
        }
    }
}
