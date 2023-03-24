using Microsoft.Extensions.Caching.Distributed;

namespace TN.Modules.Buildings.Shared.Persistance.Caching
{
    internal sealed class CacheDataAccess : ICacheDataAccess
    {
        private readonly IDistributedCache _cache;

        public CacheDataAccess(IDistributedCache cache)
        {
            _cache = cache;
        }

        public Task<IReadOnlyList<T>> GetCatalog<T>()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetCompany(int id)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetTenant(int id)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetProvider(int id)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetService(int id)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetUser(int id)
        {
            throw new NotImplementedException();
        }
    }
}
