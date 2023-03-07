using Microsoft.Extensions.DependencyInjection;

namespace TN.Modules.Logger.Domain
{
    public static class Extensions
    {
        public static IServiceCollection AddDomainLayer(this IServiceCollection services)
        {
            return services;
        }
    }
}
