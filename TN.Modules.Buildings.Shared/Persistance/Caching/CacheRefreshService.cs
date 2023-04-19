﻿using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace TN.Modules.Buildings.Shared.Persistance.Caching
{
    public sealed class CacheRefreshService : BackgroundService
    {
        private readonly IDistributedCache _cache;
        private readonly IServiceScopeFactory _scopeFactory;

        private readonly TimeSpan _delayedStart = TimeSpan.FromSeconds(15);
        private readonly TimeSpan _refreshInterval = TimeSpan.FromHours(24);

        public CacheRefreshService(IDistributedCache cache, IServiceScopeFactory scopeFactory)
        {
            _cache = cache;
            _scopeFactory = scopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await Task.Delay(_delayedStart, stoppingToken);

            while (!stoppingToken.IsCancellationRequested)
            {
                using var scope = _scopeFactory.CreateAsyncScope();
                var cacheDataSources = scope.ServiceProvider.GetRequiredService<IEnumerable<ICacheDataSource>>();

                foreach (var cacheDataSource in cacheDataSources)
                {
                    var data = await cacheDataSource.GetData();

                    foreach (var item in data)
                    {
                        await _cache.SetRecord(item.Key, item.Value);
                    }
                }

                await Task.Delay(_refreshInterval, stoppingToken);
            }
        }
    }
}