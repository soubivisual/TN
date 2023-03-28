using TN.Modules.Buildings.Shared.Dtos;
using TN.Modules.Buildings.Shared.Mapper;
using TN.Modules.Buildings.Shared.Persistance.Caching;
using TN.Modules.Buildings.Shared.Queries;
using TN.Modules.Configurations.Domain.Catalogs.Repositories;

namespace TN.Modules.Configurations.Application.Catalogs.Queries.GetCatalog
{
    internal class GetCatalogQueryHandler : IQueryHandler<GetCatalogQuery, CatalogDto>
    {
        private readonly ICatalogRepository _catalogRepository;
        private readonly IMapping _mapping;
        private readonly ICacheDataAccess _cacheDataAccess;

        public GetCatalogQueryHandler(ICatalogRepository catalogRepository, IMapping mapping, ICacheDataAccess cacheDataAccess)
        {
            _catalogRepository = catalogRepository;
            _mapping = mapping;
            _cacheDataAccess = cacheDataAccess;
        }

        public async Task<CatalogDto> Handle(GetCatalogQuery request, CancellationToken cancellationToken)
        {
            var prueba = await _cacheDataAccess.GetCatalog("Currency");
            var catalog = await _catalogRepository.GetAsync(request.CatalogId);
            return _mapping.Map<CatalogDto>(catalog);
        }
    }
}
