using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using TN.Modules.Buildings.Shared.Mapper;
using TN.Modules.Buildings.Shared.Validator;
using TN.Modules.Identities.Application;
using TN.Modules.Identities.Domain;
using TN.Modules.Identities.Infrastructure;

namespace TN.Modules.Identities.API
{
    public static class Extensions
    {
        public static IServiceCollection AddIdentitiesModule(this IServiceCollection services)
        {
            services.AddDomainLayer();
            services.AddApplicationLayer();
            services.AddInfrastructureLayer();

            services.AddValidators(typeof(Extensions));
            services.AddMappings(typeof(Extensions));

            return services;
        }

        public static IApplicationBuilder UseIdentitiesModule(this IApplicationBuilder app)
        {
            return app;
        }
    }
}
