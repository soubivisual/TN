using TN.Modules.Buildings.Application.Contracts;

namespace TN.Modules.Configurations.Application.Catalogs.Commands.AddCatalog
{
    public sealed record AddCatalogCommand(Guid Id) : ICommand;
}
