using TN.Modules.Buildings.Shared.Dtos;
using TN.Modules.Buildings.Shared.Mapper;
using TN.Modules.Buildings.Shared.Queries;
using TN.Modules.Configurations.Domain.Catalogs.Repositories;

namespace TN.Modules.Configurations.Application.Catalogs.Queries.GetAllCatalogs
{
    internal class GetAllCatalogsQueryHandler : IQueryHandler<GetAllCatalogsQuery, IReadOnlyList<CatalogDto>>
    {
        private readonly ICatalogRepository _catalogRepository;
        private readonly IMapping _mapping;

        public GetAllCatalogsQueryHandler(ICatalogRepository catalogRepository, IMapping mapping)
        {
            _catalogRepository = catalogRepository;
            _mapping = mapping;
        }

        public async Task<IReadOnlyList<CatalogDto>> Handle(GetAllCatalogsQuery request, CancellationToken cancellationToken)
        {
            var catalogs = await _catalogRepository.GetAllAsync();
            return _mapping.Map<IReadOnlyList<CatalogDto>>(catalogs);
        }
    }
}
