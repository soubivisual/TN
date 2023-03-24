using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TN.Shared.Utils.Misc;

namespace TN.Modules.Buildings.Shared.Persistance.Caching
{
    public static class Extensions
    {
        private const int RedisMaxConnectRetry = 3;

        private static readonly TimeSpan AbsoluteExpiration = new(24, 0, 0);
        private static readonly TimeSpan SlidingExpiration = new(24, 0, 0);

        public static IServiceCollection AddCaching(this IServiceCollection services)
        {
            services.AddStackExchangeRedisCache(options =>
            {
                var configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();
                var connectionString = configuration[$"{nameof(ConnectionStrings)}:{ConnectionStrings.Caching}"];
                var endPoints = connectionString.Split(",");
                //options.Configuration = connectionString; // Esta línea funciona si no se usan los ConfigurationOptions
                options.InstanceName = Assembly.GetEntryAssembly().GetName().Name;
                options.ConfigurationOptions = new(); // Corrección para que no haya latencia en toda la aplicación cuando no hay conexión con Redis
                endPoints.ToList().ForEach(hostAndPort => options.ConfigurationOptions.EndPoints.Add(hostAndPort));
                options.ConfigurationOptions.AbortOnConnectFail = false;
                options.ConfigurationOptions.ConnectRetry = RedisMaxConnectRetry;
            });

            return services;
        }

        public static async Task SetRecord<T>(this IDistributedCache cache, string key, T value, TimeSpan? absoluteExpireTime = null, TimeSpan? unusedExpireTime = null)
        {
            var options = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = absoluteExpireTime ?? AbsoluteExpiration,
                SlidingExpiration = unusedExpireTime ?? SlidingExpiration
            };

            await cache.SetStringAsync(key, value.ToJson(), options);
        }

        public static async Task<T> GetRecord<T>(this IDistributedCache cache, string key)
        {
            var value = await cache.GetStringAsync(key);

            if (value == null)
                return default;

            return value.FromJson<T>();
        }
    }
}
