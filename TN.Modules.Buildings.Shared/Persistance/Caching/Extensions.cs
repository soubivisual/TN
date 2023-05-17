using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TN.Shared.Utils.Misc;

namespace TN.Modules.Buildings.Shared.Persistance.Caching
{
    public static class Extensions
    {
        private const string InstanceName = "TN";

        private static readonly TimeSpan? AbsoluteExpiration = null;
        private static readonly TimeSpan? SlidingExpiration = null;

        public static IServiceCollection AddCaching(this IServiceCollection services)
        {
            var configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();
            var connectionString = configuration[$"{nameof(ConnectionStrings)}:{ConnectionStrings.Caching}"];
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = connectionString;
                options.InstanceName = $"{InstanceName}_{environment}_";
            });

            services.AddHostedService<CacheRefreshService>();

            services.AddSingleton<ICacheDataAccess, CacheDataAccess>();

            return services;
        }

        internal static async Task SetRecord<T>(this IDistributedCache cache, string key, T value, TimeSpan? absoluteExpireTime = null, TimeSpan? unusedExpireTime = null)
        {
            var options = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = absoluteExpireTime ?? AbsoluteExpiration,
                SlidingExpiration = unusedExpireTime ?? SlidingExpiration
            };

            await cache.SetStringAsync(key, value.ToJson(), options);
        }

        internal static async Task<T> GetRecord<T>(this IDistributedCache cache, string key)
        {
            var value = await cache.GetStringAsync(key);

            if (value == null)
            {
                return default;
            }

            return value.FromJson<T>();
        }
    }
}
