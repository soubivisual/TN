using Microsoft.Extensions.DependencyInjection;
using TN.Modules.Buildings.Infrastructure.Persistance.Database;
using TN.Modules.Notifications.Application.Contracts;
using TN.Modules.Notifications.Domain.Notifications.Repositories;
using TN.Modules.Notifications.Infrastructure.DataAccess;
using TN.Modules.Notifications.Infrastructure.Repositories;

namespace TN.Modules.Notifications.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services)
        {
            services.AddDatabase<NotificationsDbContext>();

            services.AddTransient<INotificationsAccessModule, NotificationsAccessModule>();

            services.AddScoped<INotificationRepository, NotificationRepository>();

            return services;
        }
    }
}
