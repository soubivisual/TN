using Microsoft.Extensions.Caching.Distributed;
using TN.Modules.Buildings.Shared.Dtos;

namespace TN.Modules.Buildings.Shared.Persistance.Caching
{
    internal sealed class CacheDataAccess : ICacheDataAccess
    {
        private readonly IDistributedCache _cache;

        public CacheDataAccess(IDistributedCache cache)
        {
            _cache = cache;
        }

        public Task<IReadOnlyList<CatalogDto>> GetCatalog(string type)
            => _cache.GetRecord<IReadOnlyList<CatalogDto>>(type);

        public Task<string> GetCompany(int id)
            => _cache.GetRecord<string>($"Company_{id}");

        public Task<string> GetTenant(int id)
            => _cache.GetRecord<string>($"Tenant_{id}");

        public Task<string> GetProvider(int id)
            => _cache.GetRecord<string>($"Provider_{id}");

        public Task<string> GetService(int id)
            => _cache.GetRecord<string>($"Service_{id}");

        public Task<UserDto> GetUser(int id)
            => _cache.GetRecord<UserDto>($"User_{id}");
    }
}
