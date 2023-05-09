using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using TN.Client.Services.Remittance.Implementations.General;
using TN.Client.Services.Remittance.Interfaces;

namespace TN.Client.Services.Remittance
{
    public static class Extensions
    {
        public static IServiceCollection AddRemittanceServices(this IServiceCollection services)
        {
            services.AddTransient<IRemittanceService, RemittanceService>();

            return services;
        }

        public static IApplicationBuilder UseRemittanceServices(this IApplicationBuilder app)
        {
            return app;
        }
    }
}
