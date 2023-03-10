using System.ComponentModel.DataAnnotations;

namespace TN.Client.Components.Shared.Models.Authentication
{
    internal sealed class LoginModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
