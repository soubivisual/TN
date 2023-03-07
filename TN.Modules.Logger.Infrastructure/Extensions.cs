using Microsoft.Extensions.DependencyInjection;
using TN.Modules.Building.Infrastructure.Persistance.Database;
using TN.Modules.Identity.Application.Contracts;
using TN.Modules.Logger.Domain.ApplicationLogs.Repositories;
using TN.Modules.Logger.Infrastructure.DataAccess;
using TN.Modules.Logger.Infrastructure.Repositories;

namespace TN.Modules.Logger.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services)
        {
            services.AddDatabase<LoggerDbContext>();

            services.AddTransient<ILoggerAccessModule, LoggerAccessModule>();

            services.AddScoped<IApplicationLogRepository, ApplicationLogRepository>();

            return services;
        }
    }
}
