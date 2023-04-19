using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace TN.Admin.Services.API.Contracts.Catalogs
{
	[DataContract]
	public class CreateCatalogRequest : BaseRequest
	{
		[Required(ErrorMessage = "El campo Tipo es requerido")]
		[StringLength(50)]
		public string Type { get; set; } = string.Empty;
		[Required]
		[StringLength(200)]
		public string Value { get; set; } = string.Empty;

		public bool Editable { get; set; }

		public bool Enabled { get; set; }

		public int? Int1 { get; set; }

		public int? Int2 { get; set; }

		[StringLength(200)]
		public string Nvarchar1 { get; set; } = string.Empty;

		[StringLength(500)]
		public string Nvarchar2 { get; set; } = string.Empty;

		[StringLength(3000)]
		public string Nvarchar3 { get; set; } = string.Empty;

		public bool? Bool1 { get; set; }

		public double? Float1 { get; set; }
		[Column(TypeName = "decimal(18,2)")]
		public decimal? Decimal1 { get; set; }

		public int UserId { get; set; }

		//public DateTime AddedDate { get; set; }

		//public int? EditedUserId { get; set; }

		//public DateTime? EditedDate { get; set; }
	}
}
