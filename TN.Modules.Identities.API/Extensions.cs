using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using TN.Modules.Buildings.API.Validator;
using TN.Modules.Identities.Application;
using TN.Modules.IdentitiesDomain;
using TN.Modules.IdentitiesInfrastructure;

namespace TN.Modules.IdentitiesAPI
{
    public static class Extensions
    {
        public static IServiceCollection AddIdentitiesModule(this IServiceCollection services)
        {
            services.AddDomainLayer();
            services.AddApplicationLayer();
            services.AddInfrastructureLayer();

            services.AddValidators<IAssemblyMarker>();

            return services;
        }

        public static IApplicationBuilder UseIdentitiesModule(this IApplicationBuilder app)
        {
            return app;
        }
    }
}
