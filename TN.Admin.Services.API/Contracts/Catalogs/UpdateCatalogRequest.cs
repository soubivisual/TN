namespace TN.Admin.Services.API.Contracts.Catalogs
{
	public class UpdateCatalogRequest : BaseRequest
	{
        public Guid Id { get; set; }
        public string Type { get; set; } = string.Empty;

		public string Value { get; set; } = string.Empty;

		public bool Editable { get; set; }

		public bool Enabled { get; set; }

		public int? Int1 { get; set; }

		public int? Int2 { get; set; }

		public string Nvarchar1 { get; set; } = string.Empty;

		public string Nvarchar2 { get; set; } = string.Empty;

		public string Nvarchar3 { get; set; } = string.Empty;

		public bool? Bool1 { get; set; }

		public double? Float1 { get; set; }

		public decimal? Decimal1 { get; set; }

		public int UserId { get; set; }
	}
}
