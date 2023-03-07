using System.ComponentModel.DataAnnotations;

namespace TN.Client.Web.BlazorShared.Models.Profile
{
    public class ChangePhoneModel : BaseModel
    {
        [Phone(ErrorMessage = "Formato no válido para el campo {0}")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Teléfono", Prompt = "Digite su teléfono")]
        public string Phone { get; set; }

        [Phone(ErrorMessage = "Formato no válido para el campo {0}")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Compare(nameof(Phone), ErrorMessage = "Ambos teléfonos deben coincidir")]
        [Display(Name = "Confirmar Teléfono", Prompt = "Confirme su teléfono")]
        public string ConfirmPhone { get; set; }
    }
}
