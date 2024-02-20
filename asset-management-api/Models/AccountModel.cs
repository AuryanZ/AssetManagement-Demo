using System.ComponentModel.DataAnnotations;

namespace AssetManagement.Models
{
    public class AccountModel
    {
        public int Id { get; set; }
        [Required]
        public bool IsActive { get; set;}
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Role { get; set; }
        [Required]
        public DateTime CreatDate { get; set; }
        [Required]
        public DateTime LastLogin { get; set; }
        public string Email { get; set; }
    }
}