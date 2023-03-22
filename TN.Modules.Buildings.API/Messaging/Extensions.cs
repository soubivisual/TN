using Microsoft.Extensions.DependencyInjection;

namespace TN.Modules.Buildings.API.Messaging
{
    internal static class Extensions
    {
        public static IServiceCollection AddMessaging(this IServiceCollection services)
        {
            services.AddHostedService<MessageBusSubscriber>();
            services.AddSingleton<IMessageBusPublisher, MessageBusPublisher>();

            return services;
        }
    }
}
