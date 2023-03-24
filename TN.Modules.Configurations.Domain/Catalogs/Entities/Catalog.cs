using TN.Modules.Buildings.Shared.SharedKernel;
using TN.Modules.Configurations.Domain.Catalogs.ValueObjects;

namespace TN.Modules.Configurations.Domain.Catalogs.Entities
{
    public sealed class Catalog : EntityBase<CatalogId>
    {
        public CatalogType Type { get; private set; }

        public string Value { get; private set; }

        public bool Editable { get; private set; }

        public bool Enabled { get; private set; }

        public int? Int1 { get; private set; }

        public int? Int2 { get; private set; }

        public string Nvarchar1 { get; private set; }

        public string Nvarchar2 { get; private set; }

        public string Nvarchar3 { get; private set; }

        public string Nvarchar4 { get; private set; }

        public string Nvarchar5 { get; private set; }

        public bool? Bool1 { get; private set; }

        public decimal? Decimal1 { get; private set; }

        public decimal? Decimal2 { get; private set; }

        public Catalog() : base(default)
        {

        }

        public Catalog(CatalogId id, CatalogType type, string value, bool editable, bool enabled) : base(id)
        {
            Type = type;
            Value = value;
            Editable = editable;
            Enabled = enabled;
        }

        public Catalog(CatalogId id, CatalogType type, string value, bool editable, bool enabled, int? int1, int? int2, string nvarchar1, string nvarchar2, string nvarchar3, string nvarchar4, string nvarchar5, bool? bool1, decimal? decimal1, decimal? decimal2) : base(id)
        {
            Type = type;
            Value = value;
            Editable = editable;
            Enabled = enabled;
            Int1 = int1;
            Int2 = int2;
            Nvarchar1 = nvarchar1;
            Nvarchar2 = nvarchar2;
            Nvarchar3 = nvarchar3;
            Nvarchar4 = nvarchar4;
            Nvarchar5 = nvarchar5;
            Bool1 = bool1;
            Decimal1 = decimal1;
            Decimal2 = decimal2;
        }
    }
}
