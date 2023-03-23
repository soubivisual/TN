using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TN.Admin.Web.ASPCore.DataModels.Dto;

namespace TN.Admin.Web.ASPCore.Areas.Maintenances.Models
{
	public class CatalogModel
	{
        public CatalogDto Catalog { get; set; }
		public List<CatalogDto> Catalogs { get; set; } = new List<CatalogDto>() { new CatalogDto() {
				Id = Guid.NewGuid(),
				AddedDate = DateTime.Now,
				AddedUserId = 1,
				Editable = true,
				EditedDate = DateTime.Now,
				EditedUserId = 1,
				Enabled = true,
				Type = "CatalogType",
				Value = "Tipo Catalogo1",
			},
			new CatalogDto() {
				Id = Guid.NewGuid(),
				AddedDate = DateTime.Now,
				AddedUserId = 1,
				Editable = false,
				EditedDate = DateTime.Now,
				EditedUserId = 1,
				Enabled = false,
				Type = "CatalogType2",
				Value = "Tipo Catalogo2",
			},
		};
	}
}
