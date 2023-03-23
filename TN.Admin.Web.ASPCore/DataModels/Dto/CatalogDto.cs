using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TN.Admin.Web.ASPCore.DataModels.Dto
{
	public class CatalogDto
	{
		[Key]
		[Required]
		public Guid Id { get; set; }

		[Required]
		[StringLength(50)]
		[Display(Name = "Tipo")]
		public string Type { get; set; }

		[Required]
		[StringLength(200)]
		[Display(Name = "Valor")]
		public string Value { get; set; }

		[Required]
		public bool Editable { get; set; }

		[Required]
		public bool Enabled { get; set; }

		public int? Int1 { get; set; }

		public int? Int2 { get; set; }

		[StringLength(200)]
		public string Nvarchar1 { get; set; }

		[StringLength(500)]
		public string Nvarchar2 { get; set; }

		[StringLength(3000)]
		public string Nvarchar3 { get; set; }

		public bool? Bool1 { get; set; }

		public double? Float1 { get; set; }

		[Column(TypeName = "decimal(18,2)")]
		public decimal? Decimal1 { get; set; }

		public int? AddedUserId { get; set; }

		[Required]
		public DateTime AddedDate { get; set; }

		public int? EditedUserId { get; set; }

		public DateTime? EditedDate { get; set; }

	}
}
