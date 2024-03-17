using System.ComponentModel.DataAnnotations;

namespace HmzTest.Dtos.Account
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public required string Email { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        [MinLength(8, ErrorMessage = "Password must be at least 3 characters long.")]
        public required string Password { get; set; }
    }
}
