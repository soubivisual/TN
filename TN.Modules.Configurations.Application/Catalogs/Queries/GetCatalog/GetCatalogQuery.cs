using TN.Modules.Buildings.Application.Contracts;

namespace TN.Modules.Configurations.Application.Catalogs.Queries.GetCatalog
{
    public sealed record GetCatalogQuery(Guid CatalogId) : IQuery<CatalogDto>
    {

    }
}
