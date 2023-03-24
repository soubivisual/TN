using TN.Modules.Buildings.Shared.Queries;

namespace TN.Modules.Configurations.Application.Catalogs.Queries.GetCatalog
{
    public sealed record GetCatalogQuery(Guid CatalogId) : IQuery<CatalogDto>
    {

    }
}
