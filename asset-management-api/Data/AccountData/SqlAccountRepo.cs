using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using AssetManagement.Dtos;
using AssetManagement.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using static AssetManagement.Dtos.ServiceResponses;

namespace AssetManagement.Data
{
    public class SqlAccountRepo(
        UserManager<AppUser> userManager,
        RoleManager<IdentityRole> roleManager,
        IConfiguration config) : IAccountRepo
    {
        public async Task<AccountServiceResponse> Login(AccountLoginDto account)
        {
            if (account == null) return new AccountServiceResponse(false, null, 0, null, "Account is null");

            var getUser = await userManager.FindByNameAsync(account.Username);
            if (getUser == null) return new AccountServiceResponse(false, null, 0, null, "User not found");

            bool password = await userManager.CheckPasswordAsync(getUser, account.Password);
            if (!password) return new AccountServiceResponse(false, null, 0, null, "Password is incorrect");

            var userRoles = await userManager.GetRolesAsync(getUser);
            var userSession = new AccountSession(getUser.Id, getUser.UserName, getUser.Email, userRoles[0]);

            string accessToken = GenerateJwtToken(userSession);

            string refreshToken = GenerateRefreshToken();

            getUser.RefreshToken = refreshToken;
            _ = int.TryParse(config["JWT:RefreshTokenValidityInDays"], out int refreshTokenValidityInDays);
            getUser.RefreshTokenExpiryTime = DateTime.Now.AddDays(refreshTokenValidityInDays);
            await userManager.UpdateAsync(getUser);

            _ = int.TryParse(config["JWT:TokenValidityInMinutes"], out int tokenValidityInMinutes);

            return new AccountServiceResponse(true, accessToken, tokenValidityInMinutes, refreshToken, "Login successful");
        }

        public async Task<GeneralServiceResponse> Register(AccountModel account)
        {
            if (account == null) return new GeneralServiceResponse(false, "Account is null");
            var newUser = new AppUser
            {
                Name = account.Username,
                UserName = account.Username,
                Email = account.Email,
                PasswordHash = account.Password,

            };
            var user = await userManager.FindByEmailAsync(newUser.Email);
            if (user != null) return new GeneralServiceResponse(false, "Email already exists");

            var createdUser = await userManager.CreateAsync(newUser, account.Password);
            if (!createdUser.Succeeded) return new GeneralServiceResponse(false, "Account not created");

            var role = await roleManager.FindByNameAsync(account.Role);
            if (role == null)
            {
                await roleManager.CreateAsync(new IdentityRole(account.Role));
                await userManager.AddToRoleAsync(newUser, account.Role);
                return new GeneralServiceResponse(true, "Account created");
            }
            else
            {
                await userManager.AddToRoleAsync(newUser, account.Role);
                return new GeneralServiceResponse(true, "Account created");

            }
        }

        public async Task<AccountServiceResponse> RefreshToken(AccountToken accountToken)
        {
            if (accountToken == null) return new AccountServiceResponse(false, null, 0, null, "Account is null");

            string accessToken = accountToken.AccessToken;
            string refreshToken = accountToken.RefreshToken;

            var principal = GetPrincipalFromExpiredToken(accessToken);
            if (principal == null) return new AccountServiceResponse(false, null, 0, null, "Invalid token");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            var username = principal.Identity.Name;
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            var user = await userManager.FindByNameAsync(username);
            if (user == null || user.RefreshToken != refreshToken || user.RefreshTokenExpiryTime <= DateTime.Now)
                return new AccountServiceResponse(false, null, 0, null, "Invalid token");

            var userRoles = await userManager.GetRolesAsync(user);
            var userSession = new AccountSession(user.Id, user.UserName, user.Email, userRoles[0]);

            string newAccessToken = GenerateJwtToken(userSession);
            string newRefreshToken = GenerateRefreshToken();

            user.RefreshToken = newRefreshToken;
            _ = int.TryParse(config["JWT:RefreshTokenValidityInDays"], out int refreshTokenValidityInDays);
            user.RefreshTokenExpiryTime = DateTime.Now.AddDays(refreshTokenValidityInDays);
            await userManager.UpdateAsync(user);

            _ = int.TryParse(config["JWT:TokenValidityInMinutes"], out int tokenValidityInMinutes);

            return new AccountServiceResponse(true, newAccessToken, tokenValidityInMinutes, newRefreshToken, "Token refreshed");
        }

        private string GenerateJwtToken(AccountSession user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role)
            };
            _ = int.TryParse(config["JWT:TokenValidityInMinutes"], out int tokenValidityInMinutes);
            var token = new JwtSecurityToken(
                config["Jwt:Issuer"],
                config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(tokenValidityInMinutes),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        private ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"])),
                ValidateLifetime = false
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");
            return principal;
        }
    }
}