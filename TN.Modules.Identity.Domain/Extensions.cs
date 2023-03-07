using Microsoft.Extensions.DependencyInjection;

namespace TN.Modules.Identity.Domain
{
    public static class Extensions
    {
        public static IServiceCollection AddDomainLayer(this IServiceCollection services)
        {
            return services;
        }
    }
}