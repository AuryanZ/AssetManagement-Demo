using Microsoft.AspNetCore.Identity;

namespace AssetManagement.Data
{
    public class AppUser : IdentityUser
    {
        // public string UserName { get; set; }

        public bool IsActive { get; set; }

        public string RefreshToken { get; set; }

        public string Role { get; set; }

        public DateTime RefreshTokenExpiryTime { get; set; }

        public DateTime LastLogin { get; set; }

        public DateTime CreatedDate { get; set; }

    }
}