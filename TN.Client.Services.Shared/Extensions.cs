using Microsoft.AspNetCore.Builder;
using Mobile = TN.Client.Services.Shared.Implementations.Mobile;
using Web = TN.Client.Services.Shared.Implementations.Web;
using TN.Client.Services.Shared.Interfaces;
using TN.Client.Services.Shared.Implementations.Shared;
using Microsoft.Extensions.Options;
using TN.Client.Services.Shared.Configurations;

namespace TN.Client.Services.Shared
{
    public static class Extensions
    {
        public static IServiceCollection AddMobileSharedServices(this IServiceCollection services, Action<ApplicationServiceOptions> options)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options),
                    @"Please provide options for AddMobileSharedServices.");
            }
            services.Configure(options);
            services.AddSingleton<ILocalizerService, LocalizerService>();
            services.AddTransient<IVibrationService, Mobile.VibrationService>();
            services.AddTransient<IGeolocationService, Mobile.GeolocationService>();
            services.AddTransient<IApplicationInformation, ApplicationInformationService>();

            services.AddTransient<IMenuService, MenuService>();

            return services;
        }

        public static IApplicationBuilder UseMobileSharedServices(this IApplicationBuilder app)
        {
            return app;
        }

        public static IServiceCollection AddWebSharedServices(this IServiceCollection services, Action<ApplicationServiceOptions> options)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options),
                    @"Please provide options for AddWebSharedServices.");
            }
            services.Configure(options);
            services.AddSingleton<ILocalizerService, LocalizerService>();
            services.AddTransient<IVibrationService, Web.VibrationService>();
            services.AddTransient<IGeolocationService, Web.GeolocationService>();
            services.AddTransient<IApplicationInformation, ApplicationInformationService>();

            services.AddTransient<IMenuService, MenuService>();

            return services;
        }

        public static IApplicationBuilder UseWebSharedServices(this IApplicationBuilder app)
        {
            return app;
        }
    }
}
