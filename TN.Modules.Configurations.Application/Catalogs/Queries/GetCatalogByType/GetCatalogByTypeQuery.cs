using TN.Modules.Buildings.Shared.Dtos;
using TN.Modules.Buildings.Shared.Queries;

namespace TN.Modules.Configurations.Application.Catalogs.Queries.GetCatalogByType
{
    public sealed record GetCatalogByTypeQuery(string Type) : IQuery<IReadOnlyList<CatalogDto>>
    {

    }
}
