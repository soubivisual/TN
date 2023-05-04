using System.ComponentModel.DataAnnotations;

namespace TN.Client.Components.Shared.Models.Authentication
{
    public sealed class LoginModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Comment { get; set; }
    }
}
