using Microsoft.Extensions.DependencyInjection;
using TN.Modules.Identities.Application.Contracts;
using TN.Modules.IdentitiesDomain.Users.Repositories;
using TN.Modules.IdentitiesInfrastructure.DataAccess;
using TN.Modules.IdentitiesInfrastructure.Repositories;
using TN.Modules.Buildings.Infrastructure.Persistance.Database;

namespace TN.Modules.IdentitiesInfrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services)
        {
            services.AddDatabase<IdentitiesDbContext>();

            services.AddTransient<IIdentitiesAccessModule, IdentitiesAccessModule>();

            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
