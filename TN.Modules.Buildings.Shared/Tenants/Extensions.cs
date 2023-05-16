using Microsoft.Extensions.DependencyInjection;

namespace TN.Modules.Buildings.Shared.Tenants
{
    public static class Extensions
    {
        public static IServiceCollection AddTenantService(this IServiceCollection services)
        {
            services.AddTransient<ITenantService, TenantService>();

            return services;
        }
    }
}
