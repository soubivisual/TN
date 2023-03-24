﻿using Microsoft.Extensions.DependencyInjection;
using TN.Modules.Buildings.Shared.Mapper;
using TN.Modules.Buildings.Shared.Mediator;

namespace TN.Modules.Notifications.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            services.AddMediator(typeof(Extensions));
            services.AddMappings(typeof(Extensions));

            return services;
        }
    }
}
