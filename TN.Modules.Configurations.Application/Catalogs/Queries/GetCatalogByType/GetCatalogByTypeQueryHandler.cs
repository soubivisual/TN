using TN.Modules.Buildings.Shared.Dtos;
using TN.Modules.Buildings.Shared.Mapper;
using TN.Modules.Buildings.Shared.Queries;
using TN.Modules.Configurations.Domain.Catalogs.Repositories;

namespace TN.Modules.Configurations.Application.Catalogs.Queries.GetCatalogByType
{
    internal class GetCatalogByTypeQueryHandler : IQueryHandler<GetCatalogByTypeQuery, IReadOnlyList<CatalogDto>>
    {
        private readonly ICatalogRepository _catalogRepository;
        private readonly IMapping _mapping;

        public GetCatalogByTypeQueryHandler(ICatalogRepository catalogRepository, IMapping mapping)
        {
            _catalogRepository = catalogRepository;
            _mapping = mapping;
        }

        public async Task<IReadOnlyList<CatalogDto>> Handle(GetCatalogByTypeQuery request, CancellationToken cancellationToken)
        {
            var catalog = await _catalogRepository.GetByTypeAsync(request.Type);
            return _mapping.Map<IReadOnlyList<CatalogDto>>(catalog);
        }
    }
}
