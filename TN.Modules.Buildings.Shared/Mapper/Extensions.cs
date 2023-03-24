using Mapster;
using Microsoft.Extensions.DependencyInjection;

namespace TN.Modules.Buildings.Shared.Mapper
{
    public static class Extensions
    {
        public static IServiceCollection AddMappings(this IServiceCollection services, Type type)
        {
            var config = TypeAdapterConfig.GlobalSettings;
            config.Scan(type.Assembly);

            services.AddSingleton(config);
            services.AddScoped<IMapping, Mapping>();

            return services;
        }
    }
}
