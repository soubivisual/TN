using TN.Modules.Buildings.Shared.Commands;
using TN.Modules.Buildings.Shared.Mapper;
using TN.Modules.Configurations.Domain.Catalogs.Repositories;
using TN.Modules.Configurations.Domain.Catalogs.Aggregates;

namespace TN.Modules.Configurations.Application.Catalogs.Commands.UpdateCatalog
{
    internal class UpdateCatalogCommandHandler : ICommandHandler<UpdateCatalogCommand>
    {
        private readonly ICatalogRepository _catalogRepository;
        private readonly IMapping _mapping;

        public UpdateCatalogCommandHandler(ICatalogRepository catalogRepository, IMapping mapping)
        {
            _catalogRepository = catalogRepository;
            _mapping = mapping;
        }

        public async Task Handle(UpdateCatalogCommand command, CancellationToken cancellationToken)
        {
            var catalog = _mapping.Map<Catalog>(command);
            catalog.Id = command.Id;
            await _catalogRepository.UpdateAsync(catalog);
        }
    }
}
