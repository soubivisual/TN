using Microsoft.Extensions.DependencyInjection;

namespace TN.Modules.Buildings.Shared.Mediator
{
    public static class Extensions
    {
        public static IServiceCollection AddMediator(this IServiceCollection services, Type type)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(type.Assembly));

            return services;
        }
    }
}
