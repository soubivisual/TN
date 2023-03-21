using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TN.Modules.Buildings.API.Database;
using TN.Modules.Buildings.API.Events;
using TN.Modules.Buildings.API.Exceptions;
using TN.Modules.Buildings.API.Messaging;
using TN.Shared.Utils.Misc.Time;

namespace TN.Modules.Buildings.API
{
    public static class Extensions
    {
        public static IServiceCollection AddSharedFramework(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddEndpointsApiExplorer();
            services.AddErrorHandling();
            services.AddEvents();
            services.AddMessaging();
            services.DatabaseMigration(configuration);
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSingleton<IClock, UtcClock>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
#if DEBUG
            services.AddSwaggerGen();
#endif

            return services;
        }

        public static IApplicationBuilder UseSharedFramework(this IApplicationBuilder app)
        {
#if DEBUG
            app.UseSwagger();
            app.UseSwaggerUI();
#endif
            app.UseErrorHandling();
            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseAuthorization();

            return app;
        }
    }
}
