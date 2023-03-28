using TN.Modules.Buildings.Shared.Dtos;
using TN.Modules.Buildings.Shared.Queries;

namespace TN.Modules.Configurations.Application.Catalogs.Queries.GetAllCatalogs
{
    public sealed record class GetAllCatalogsQuery() : IQuery<IReadOnlyList<CatalogDto>>
    {

    }
}
