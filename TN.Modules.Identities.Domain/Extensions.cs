using Microsoft.Extensions.DependencyInjection;

namespace TN.Modules.IdentitiesDomain
{
    public static class Extensions
    {
        public static IServiceCollection AddDomainLayer(this IServiceCollection services)
        {
            return services;
        }
    }
}