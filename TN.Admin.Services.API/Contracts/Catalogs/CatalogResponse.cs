namespace TN.Admin.Services.API.Contracts.Catalogs
{
	public class CatalogResponse : BaseResponse
	{
		public Guid Id { get; set; }

		public string Type { get; set; }

		public string Value { get; set; }

		public bool Editable { get; set; }

		public bool Enabled { get; set; }

		public int? Int1 { get; set; }

		public int? Int2 { get; set; }

		public string Nvarchar1 { get; set; }

		public string Nvarchar2 { get; set; }

		public string Nvarchar3 { get; set; }

		public bool? Bool1 { get; set; }

		public double? Float1 { get; set; }

		public decimal? Decimal1 { get; set; }

		public int? AddedUserId { get; set; }

		public DateTime AddedDate { get; set; }

		public int? EditedUserId { get; set; }

		public DateTime? EditedDate { get; set; }
	}
}
