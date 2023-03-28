using TN.Modules.Buildings.Shared.Queries;

namespace TN.Modules.Configurations.Application.Catalogs.Queries.GetCatalogTypes
{
    public sealed record class GetTypesQuery() : IQuery<IReadOnlyList<string>>
    {

    }
}
