using TN.Modules.Buildings.Shared.Persistance.Caching;
using TN.Modules.Configurations.Domain.Catalogs.Repositories;

namespace TN.Modules.Configurations.Infrastructure.Caching
{
    internal sealed class CacheDataSource : ICacheDataSource
    {
        private readonly ICatalogRepository _catalogRepository;

        public CacheDataSource(ICatalogRepository catalogRepository)
        {
            _catalogRepository = catalogRepository;
        }

        public async Task<Dictionary<string, object>> GetData()
        {
            var response = new Dictionary<string, object>();
            var catalogTypes = await _catalogRepository.GetTypesAsync();

            foreach (var type in catalogTypes)
            {
                response[type] = await _catalogRepository.GetByTypeAsync(type);
            }

            return response;
        }
    }
}
