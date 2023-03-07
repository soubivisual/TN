using Microsoft.Extensions.DependencyInjection;
using TN.Modules.Identity.Application.Contracts;
using TN.Modules.Identity.Domain.Users.Repositories;
using TN.Modules.Identity.Infrastructure.DataAccess;
using TN.Modules.Identity.Infrastructure.Repositories;
using TN.Modules.Building.Infrastructure.Persistance.Database;

namespace TN.Modules.Identity.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services)
        {
            services.AddDatabase<IdentityDbContext>();

            services.AddTransient<IIdentityAccessModule, IdentityAccessModule>();

            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
