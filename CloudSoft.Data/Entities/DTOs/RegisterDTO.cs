using System.ComponentModel.DataAnnotations;

namespace CloudSoft.Data.Entities.DTOs
{
    public class RegisterDTO
    {
        [Required(ErrorMessage = "user name is required")]
        public string? UserName { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }
    }
}
