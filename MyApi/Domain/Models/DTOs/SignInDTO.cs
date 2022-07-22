using System.ComponentModel.DataAnnotations;

namespace MyApi.Domain.Models.DTOs
{
    public class SignInDTO
    {
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
