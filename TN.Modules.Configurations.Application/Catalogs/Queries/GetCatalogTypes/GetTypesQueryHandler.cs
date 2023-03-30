using TN.Modules.Buildings.Shared.Mapper;
using TN.Modules.Buildings.Shared.Queries;
using TN.Modules.Configurations.Domain.Catalogs.Repositories;

namespace TN.Modules.Configurations.Application.Catalogs.Queries.GetCatalogTypes
{
    internal class GetTypesQueryHandler : IQueryHandler<GetTypesQuery, IReadOnlyList<string>>
    {
        private readonly ICatalogRepository _catalogRepository;
        private readonly IMapping _mapping;

        public GetTypesQueryHandler(ICatalogRepository catalogRepository, IMapping mapping)
        {
            _catalogRepository = catalogRepository;
            _mapping = mapping;
        }

        public async Task<IReadOnlyList<string>> Handle(GetTypesQuery request, CancellationToken cancellationToken)
        {
            var types = await _catalogRepository.GetTypesAsync();
            return _mapping.Map<IReadOnlyList<string>>(types);
        }
    }
}
