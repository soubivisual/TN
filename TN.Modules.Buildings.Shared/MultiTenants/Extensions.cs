using Finbuckle.MultiTenant;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace TN.Modules.Buildings.Shared.MultiTenants
{
    public static class Extensions
    {
        public static IServiceCollection AddMultitenants(this IServiceCollection services)
        {
            services.AddMultiTenant<TenantInfo>()
                .WithClaimStrategy("iss")
                .WithConfigurationStore();

            return services;
        }

        public static IApplicationBuilder UseMultitenants(this IApplicationBuilder app)
        {
            app.UseMultiTenant();

            return app;
        }
    }
}
