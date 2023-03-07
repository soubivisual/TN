using System.ComponentModel.DataAnnotations;

namespace TN.Client.Web.BlazorShared.Models.Profile
{
    public class ChangeNameModel : BaseModel
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 30, MinimumLength = 1, ErrorMessage = "El campo {0} debe contar con mínimo {2} caracter y máximo {1}")]
        [Display(Name = "Nombre", Prompt = "Digite su Nombre")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 30, MinimumLength = 1, ErrorMessage = "El campo {0} debe contar con mínimo {2} caracter y máximo {1}")]
        [Display(Name = "Apellidos", Prompt = "Digite sus Apellidos")]
        public string LastName { get; set; }

        public string FullName => $"{Name} {LastName}";
    }
}
