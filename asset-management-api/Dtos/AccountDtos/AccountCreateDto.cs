using System.ComponentModel.DataAnnotations;

namespace AssetManagement.Dtos
{
    public class AccountCreateDto
    {
        [Required(ErrorMessage = "Username is required")]
        [MinLength(5, ErrorMessage = "Username must be at least 5 characters")]
        public string Username { get; set; }
        
        [Required(ErrorMessage = "Password is required")]
        [MinLength(5, ErrorMessage = "Password must be at least 5 characters")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        public string Role { get; set; }
        public DateTime CreatDate { get; set; }
        public bool IsActive { get; set; }
    }
}