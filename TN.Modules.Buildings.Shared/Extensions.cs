﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TN.Modules.Buildings.Shared.Events;
using TN.Modules.Buildings.Shared.Exceptions;
using TN.Modules.Buildings.Shared.HealthChecks;
using TN.Modules.Buildings.Shared.Messaging;
using TN.Modules.Buildings.Shared.Persistance.Caching;
using TN.Modules.Buildings.Shared.Persistance.Database;
using TN.Modules.Buildings.Shared.MultiTenants;
using TN.Modules.Buildings.Shared.Time;
using TN.Modules.Buildings.Shared.Authentication;
using TN.Modules.Buildings.Shared.ApiDocs;

namespace TN.Modules.Buildings.Shared
{
    public static class Extensions
    {
        public static IServiceCollection AddSharedFramework(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddErrorHandling();
            services.AddEvents();
            services.AddMessaging();
            services.AddCaching();
            services.AddMultitenants();
            services.DatabaseMigration();
            services.AddModulesHealthChecks();
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddAPIAuthentication(configuration);
            services.AddApiDocs();

            services.AddSingleton<IClock, UtcClock>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            return services;
        }

        public static IApplicationBuilder UseSharedFramework(this IApplicationBuilder app)
        {
            app.UseApiDocs();
            app.UseSwaggerUI();
            app.UseErrorHandling();
            app.UseMultitenants();
            app.UseAPIAuthentication();
            app.UseModulesHealthChecks();
            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseAuthorization();

            return app;
        }
    }
}
