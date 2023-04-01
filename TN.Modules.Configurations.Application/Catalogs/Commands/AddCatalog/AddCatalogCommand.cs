using TN.Modules.Buildings.Shared.Commands;

namespace TN.Modules.Configurations.Application.Catalogs.Commands.AddCatalog
{
    public sealed record AddCatalogCommand(
        Guid Id,
        string Value,
        bool Editable,
        bool Enabled,
        int? Int1,
        int? Int2,
        string Nvarchar1,
        string Nvarchar2,
        string Nvarchar3,
        string Nvarchar4,
        string Nvarchar5,
        bool? Bool1,
        decimal? Decimal1,
        decimal? Decimal2) : ICommand;
}
