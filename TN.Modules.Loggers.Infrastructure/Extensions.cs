using Microsoft.Extensions.DependencyInjection;
using TN.Modules.Buildings.Shared.Persistance.Database;
using TN.Modules.Identities.Application.Contracts;
using TN.Modules.Loggers.Domain.ApplicationLogs.Repositories;
using TN.Modules.Loggers.Domain.TraceLogs.Repositories;
using TN.Modules.Loggers.Domain.UserActivities.Repositories;
using TN.Modules.Loggers.Infrastructure.DataAccess;
using TN.Modules.Loggers.Infrastructure.DataAccess.ApplicationLogs;
using TN.Modules.Loggers.Infrastructure.DataAccess.TraceLogs;
using TN.Modules.Loggers.Infrastructure.DataAccess.UserActivities;

namespace TN.Modules.Loggers.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services)
        {
            services.AddDatabase<LoggersDbContext>();

            services.AddTransient<ILoggersAccessModule, LoggersAccessModule>();

            services.AddScoped<IApplicationLogRepository, ApplicationLogRepository>();
            services.AddScoped<ITraceLogRepository, TraceLogRepository>();
            services.AddScoped<IUserActivityRepository, UserActivityRepository>();

            return services;
        }
    }
}
