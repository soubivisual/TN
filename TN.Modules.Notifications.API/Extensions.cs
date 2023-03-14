using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using TN.Modules.Notifications.Application;
using TN.Modules.Notifications.Domain;
using TN.Modules.Notifications.Infrastructure;

namespace TN.Modules.Notifications.API
{
    public static class Extensions
    {
        public static IServiceCollection AddNotificationsModule(this IServiceCollection services)
        {
            services.AddDomainLayer();
            services.AddApplicationLayer();
            services.AddInfrastructureLayer();

            return services;
        }

        public static IApplicationBuilder UseNotificationsModule(this IApplicationBuilder app)
        {
            return app;
        }
    }
}
