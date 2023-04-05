using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using TN.Modules.Buildings.Shared.Mapper;
using TN.Modules.Buildings.Shared.Validator;
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

            services.AddValidators(typeof(Extensions));
            services.AddMappings(typeof(Extensions));

            return services;
        }

        public static IApplicationBuilder UseNotificationsModule(this IApplicationBuilder app)
        {
            return app;
        }
    }
}
