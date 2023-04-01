using TN.Modules.Buildings.Shared.Commands;
using TN.Modules.Buildings.Shared.Mapper;
using TN.Modules.Configurations.Domain.Catalogs.Repositories;
using TN.Modules.Configurations.Domain.Catalogs.Aggregates;

namespace TN.Modules.Configurations.Application.Catalogs.Commands.AddCatalog
{
    internal class AddCatalogCommandHandler : ICommandHandler<AddCatalogCommand>
    {
        private readonly ICatalogRepository _catalogRepository;
        private readonly IMapping _mapping;

        public AddCatalogCommandHandler(ICatalogRepository catalogRepository, IMapping mapping)
        {
            _catalogRepository = catalogRepository;
            _mapping = mapping;
        }

        public async Task Handle(AddCatalogCommand command, CancellationToken cancellationToken)
        {
            var catalog = _mapping.Map<Catalog>(command);
            await _catalogRepository.AddAsync(catalog);
        }
    }
}
