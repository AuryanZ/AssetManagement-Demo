using System.ComponentModel.DataAnnotations;

namespace AssetManagement.Dtos
{
    public class AccountLoginDto
    {
        [Required(ErrorMessage = "Username is required")]
        [MinLength(5, ErrorMessage = "Username must be at least 5 characters")]
        public string Username { get; set; }
        
        [Required(ErrorMessage = "Password is required")]
        [MinLength(5, ErrorMessage = "Username must be at least 5 characters")]
        public string Password { get; set; }


    }
}