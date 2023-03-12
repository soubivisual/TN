using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TN.Modules.Buildings.Infrastructure.Persistance.Database
{
    public static class Extensions
    {
        public static IServiceCollection AddDatabase<T>(this IServiceCollection services) where T : DbContext
        {
            var configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();
            var connectionString = configuration[$"{nameof(ConnectionStrings)}:{ConnectionStrings.Database}"];
            services.AddDbContext<T>(q => q.UseNpgsql(connectionString));

            return services;
        }
    }
}
