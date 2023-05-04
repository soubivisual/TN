using Microsoft.AspNetCore.Builder;
using Mobile = TN.Client.Services.Shared.Implementations.Mobile;
using Web = TN.Client.Services.Shared.Implementations.Web;
using TN.Client.Services.Shared.Interfaces;

namespace TN.Client.Services.Shared
{
    public static class Extensions
    {
        public static IServiceCollection AddMobileSharedServices(this IServiceCollection services)
        {
            services.AddTransient<IVibrationService, Mobile.VibrationService>();

            return services;
        }

        public static IApplicationBuilder UseMobileSharedServices(this IApplicationBuilder app)
        {
            return app;
        }

        public static IServiceCollection AddWebSharedServices(this IServiceCollection services)
        {
            services.AddTransient<IVibrationService, Web.VibrationService>();

            return services;
        }

        public static IApplicationBuilder UseWebSharedServices(this IApplicationBuilder app)
        {
            return app;
        }
    }
}
