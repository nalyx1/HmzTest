using System.ComponentModel.DataAnnotations;

namespace HmzTest.Dtos.Account
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "Username is required.")]
        [MinLength(3, ErrorMessage = "Username must be at least 3 characters long.")]
        [MaxLength(20, ErrorMessage = "Username cannot exceed 20 characters.")]
        public required string Username { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [MinLength(8, ErrorMessage = "Password must be at least 3 characters long.")]
        public required string Password { get; set; }

        [Required(ErrorMessage = "Password confirmation is required.")]
        [MinLength(8, ErrorMessage = "Password confirmation must be at least 3 characters long.")]
        [Compare("Password", ErrorMessage = "Password and Password Confirmation do not match.")]
        public required string PasswordConfirmation { get; set; }
    }
}
