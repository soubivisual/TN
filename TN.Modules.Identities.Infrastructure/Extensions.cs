using Microsoft.Extensions.DependencyInjection;
using TN.Modules.Buildings.Shared.Persistance.Caching;
using TN.Modules.Buildings.Shared.Persistance.Database;
using TN.Modules.Identities.Application.Contracts;
using TN.Modules.Identities.Domain.Users.Repositories;
using TN.Modules.Identities.Infrastructure.Caching;
using TN.Modules.Identities.Infrastructure.DataAccess;
using TN.Modules.Identities.Infrastructure.Repositories;

namespace TN.Modules.Identities.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services)
        {
            services.AddDatabase<IdentitiesDbContext>();

            services.AddTransient<IIdentitiesAccessModule, IdentitiesAccessModule>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICacheDataSource, CacheDataSource>();

            return services;
        }
    }
}
