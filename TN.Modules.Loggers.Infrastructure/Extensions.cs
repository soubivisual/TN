using Microsoft.Extensions.DependencyInjection;
using TN.Modules.Buildings.Infrastructure.Persistance.Database;
using TN.Modules.Identities.Application.Contracts;
using TN.Modules.Loggers.Domain.ApplicationLogs.Repositories;
using TN.Modules.Loggers.Infrastructure.DataAccess;
using TN.Modules.Loggers.Infrastructure.Repositories;

namespace TN.Modules.Loggers.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services)
        {
            services.AddDatabase<LoggersDbContext>();

            services.AddTransient<ILoggersAccessModule, LoggersAccessModule>();

            services.AddScoped<IApplicationLogRepository, ApplicationLogRepository>();

            return services;
        }
    }
}
