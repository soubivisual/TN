using TN.Modules.Buildings.Application.Configuration;
using TN.Modules.Buildings.Shared.Mapping;
using TN.Modules.Configurations.Domain.Catalogs.Repositories;

namespace TN.Modules.Configurations.Application.Catalogs.Queries.GetCatalog
{
    internal class GetCatalogQueryHandler : IQueryHandler<GetCatalogQuery, CatalogDto>
    {
        private readonly ICatalogRepository _catalogRepository;
        private readonly IMapping _mapping;

        public GetCatalogQueryHandler(ICatalogRepository catalogRepository, IMapping mapping)
        {
            _catalogRepository = catalogRepository;
            _mapping = mapping;
        }

        public async Task<CatalogDto> Handle(GetCatalogQuery request, CancellationToken cancellationToken)
        {
            var catalog = await _catalogRepository.GetAsync(request.CatalogId);
            return _mapping.Map<CatalogDto>(catalog);
        }
    }
}
