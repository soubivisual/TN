using TN.Modules.Buildings.Shared.Persistance.Caching;
using TN.Modules.Configurations.Application.Catalogs.Queries.GetCatalogByType;
using TN.Modules.Configurations.Application.Catalogs.Queries.GetCatalogTypes;
using TN.Modules.Configurations.Application.Contracts;

namespace TN.Modules.Configurations.Infrastructure.Caching
{
    internal sealed class CacheDataSource : ICacheDataSource
    {
        private readonly IConfigurationsAccessModule _configurationsAccessModule;

        public CacheDataSource(IConfigurationsAccessModule configurationsAccessModule)
        {
            _configurationsAccessModule = configurationsAccessModule;
        }

        public async Task<Dictionary<string, object>> GetData()
        {
            var response = new Dictionary<string, object>();
            var catalogTypes = await _configurationsAccessModule.ExecuteQueryAsync(new GetTypesQuery());

            foreach (var type in catalogTypes)
            {
                var catalogs = await _configurationsAccessModule.ExecuteQueryAsync(new GetCatalogByTypeQuery(type));
                response[type] = catalogs;
            }

            return response;
        }
    }
}
