namespace TN.Modules.Buildings.Shared.Dtos
{
    public sealed class CatalogDto
    {
        public Guid Id { get; set; }

        public string Type { get; private set; }

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
    }
}
