using TN.Modules.Buildings.Shared.Commands;

namespace TN.Modules.Configurations.Application.Catalogs.Commands.AddCatalog
{
    public sealed record AddCatalogCommand(Guid Id) : ICommand;
}
