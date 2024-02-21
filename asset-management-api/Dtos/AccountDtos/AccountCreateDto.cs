using System.ComponentModel.DataAnnotations;

namespace AssetManagement.Dtos
{
    public class AccountCreateDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        public string Role { get; set; }
        public DateTime CreatDate { get; set; }
        public bool IsActive { get; set; }
    }
}