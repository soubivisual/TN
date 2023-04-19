using TN.Modules.Buildings.Shared.SharedKernel;
using TN.Modules.Configurations.Domain.Catalogs.ValueObjects;

namespace TN.Modules.Configurations.Domain.Catalogs.Entities
{
    public sealed class CatalogDescription : EntityBase<CatalogDescriptionId>
    {
        public CatalogType Type { get; private set; }

        public string Int1 { get; private set; }

        public string Int2 { get; private set; }

        public string Nvarchar1 { get; private set; }

        public string Nvarchar2 { get; private set; }

        public string Nvarchar3 { get; private set; }

        public string Nvarchar4 { get; private set; }

        public string Nvarchar5 { get; private set; }

        public string Bool1 { get; private set; }

        public string Decimal1 { get; private set; }

        public string Decimal2 { get; private set; }

        public CatalogDescription() : base(default) { }

        public CatalogDescription(CatalogDescriptionId id, CatalogType type, string int1, string int2, string nvarchar1, string nvarchar2, string nvarchar3, string nvarchar4, string nvarchar5, string bool1, string decimal1, string decimal2) : base(id)
        {
            Type = type;
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
