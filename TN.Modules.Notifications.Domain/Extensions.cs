using Microsoft.Extensions.DependencyInjection;

namespace TN.Modules.Notifications.Domain
{
    public static class Extensions
    {
        public static IServiceCollection AddDomainLayer(this IServiceCollection services)
        {
            return services;
        }
    }
}
