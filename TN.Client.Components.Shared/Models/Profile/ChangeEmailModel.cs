using System.ComponentModel.DataAnnotations;

namespace TN.Client.Web.BlazorShared.Models.Profile
{
    public class ChangeEmailModel : BaseModel
    {
        [EmailAddress(ErrorMessage = "Formato no válido para el campo {0}")]
        //[RegularExpression(RegexConstant.Email, ErrorMessage = "Formato no válido para el campo {0}")] // Se puede validar con el Attribute EmailAddress o con RegularExpression. Se deja este código como referencia
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Correo Electrónico", Prompt = "Digite su correo electrónico")]
        public string Email { get; set; }

        [EmailAddress(ErrorMessage = "Formato no válido para el campo {0}")]
        //[RegularExpression(RegexConstant.Email, ErrorMessage = "Formato no válido para el campo {0}")] // Se puede validar con el Attribute EmailAddress o con RegularExpression. Se deja este código como referencia
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Compare(nameof(Email), ErrorMessage = "Ambos correos electrónicos deben coincidir")]
        [Display(Name = "Confirmar Correo Electrónico", Prompt = "Confirme su correo electrónico")]
        public string ConfirmEmail { get; set; }
    }
}
