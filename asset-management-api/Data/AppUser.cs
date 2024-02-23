using Microsoft.AspNetCore.Identity;

namespace AssetManagement.Data
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; }

        public string RefreshToken { get; set; }

        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}