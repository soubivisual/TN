using Microsoft.AspNetCore.Builder;
using Mobile = TN.Client.Services.Shared.Implementations.Mobile;
using Web = TN.Client.Services.Shared.Implementations.Web;
using TN.Client.Services.Shared.Interfaces;
using TN.Client.Services.Shared.Implementations.Shared;

namespace TN.Client.Services.Shared
{
    public static class Extensions
    {
        public static IServiceCollection AddMobileSharedServices(this IServiceCollection services, string applicationName)
        {
            services.AddTransient<IVibrationService, Mobile.VibrationService>();
            services.AddTransient<IApplicationInformation>(serviceProvider =>
            {
                return new ApplicationInformationService(applicationName);
            });

            services.AddTransient<IMenuService, MenuService>();

            return services;
        }

        public static IApplicationBuilder UseMobileSharedServices(this IApplicationBuilder app)
        {
            return app;
        }

        public static IServiceCollection AddWebSharedServices(this IServiceCollection services, string applicationName)
        {
            services.AddTransient<IVibrationService, Web.VibrationService>();
            services.AddTransient<IApplicationInformation>(serviceProvider =>
            {
                return new ApplicationInformationService(applicationName);
            });

            services.AddTransient<IMenuService, MenuService>();

            return services;
        }

        public static IApplicationBuilder UseWebSharedServices(this IApplicationBuilder app)
        {
            return app;
        }
    }
}
