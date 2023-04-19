namespace TN.Admin.Services.API.Models
{
	public class Catalog
	{
		public Guid Id { get; set; } = Guid.NewGuid();

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

		public int? AddedUserId { get; set; }

		public DateTime AddedDate { get; set; }

		public int? EditedUserId { get; set; }

		public DateTime? EditedDate { get; set; }

      
    }
}
