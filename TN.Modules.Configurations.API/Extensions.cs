﻿using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using TN.Modules.Buildings.Shared.Mapper;
using TN.Modules.Buildings.Shared.Validator;
using TN.Modules.Configurations.Application;
using TN.Modules.Configurations.Domain;
using TN.Modules.Configurations.Infrastructure;

namespace TN.Modules.Configurations.API
{
    public static class Extensions
    {
        public static IServiceCollection AddConfigurationsModule(this IServiceCollection services)
        {
            services.AddDomainLayer();
            services.AddApplicationLayer();
            services.AddInfrastructureLayer();

            services.AddValidators(typeof(Extensions));
            services.AddMappings(typeof(Extensions));

            return services;
        }

        public static IApplicationBuilder UseConfigurationsModule(this IApplicationBuilder app)
        {
            return app;
        }
    }
}
