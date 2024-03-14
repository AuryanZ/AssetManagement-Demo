using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using AssetManagement.Dtos;
using AssetManagement.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace AssetManagement.Data
{
    public class SqlAccountRepo(
        UserManager<AppUser> userManager,
        RoleManager<IdentityRole> roleManager,
        IConfiguration config) : IAccountRepo
    {
        public async Task<AccountServiceResponse> Login(AccountLoginDto account)
        {
            if (account == null) return new AccountServiceResponse(401, null, null, "Account is null");

            var getUser = await userManager.FindByNameAsync(account.Username);
            if (getUser == null) return new AccountServiceResponse(401, null, null, "User not found");
            if (!getUser.IsActive) return new AccountServiceResponse(401, null, null, "Account not active");

            bool password = await userManager.CheckPasswordAsync(getUser, account.Password);
            if (!password) return new AccountServiceResponse(401, null, null, "Password is incorrect");


            var userRoles = await userManager.GetRolesAsync(getUser);
            // var userSession = new AccountSession(getUser.Id, getUser.UserName, getUser.Email, userRoles[0]);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, getUser.Id.ToString()),
                new Claim(ClaimTypes.Name, getUser.UserName),
                new Claim(ClaimTypes.Email, getUser.Email),
                new Claim(ClaimTypes.Role, userRoles[0]),
                new Claim("username", getUser.UserName),
                new Claim("userEmail", getUser.Email),
                new Claim("userRole", userRoles[0])
            };

            string accessToken = GenerateJwtToken(claims);

            string refreshToken = GenerateRefreshToken();

            getUser.RefreshToken = refreshToken;
            _ = int.TryParse(config["JWT:RefreshTokenValidityInDays"], out int refreshTokenValidityInDays);
            getUser.RefreshTokenExpiryTime = DateTime.Now.AddDays(refreshTokenValidityInDays);
            getUser.LastLogin = DateTime.Now;
            await userManager.UpdateAsync(getUser);

            return new AccountServiceResponse(200, accessToken, refreshToken, "Login successful");
        }

        public async Task<GeneralServiceResponse> Register(AccountModel account)
        {
            if (account == null) return new GeneralServiceResponse(401, "Account is null");
            var newUser = new AppUser
            {
                // Name = account.Username,
                UserName = account.Username,
                Email = account.Email,
                PasswordHash = account.Password,
                IsActive = account.IsActive,
                CreatedDate = account.CreatDate

            };
            Console.WriteLine(newUser);
            var user = await userManager.FindByEmailAsync(newUser.Email);
            if (user != null) return new GeneralServiceResponse(409, "Email already exists");

            var createdUser = await userManager.CreateAsync(newUser, account.Password);
            if (!createdUser.Succeeded) return new GeneralServiceResponse(409, createdUser.ToString());

            var role = await roleManager.FindByNameAsync(account.Role);
            if (role == null)
            {
                await roleManager.CreateAsync(new IdentityRole(account.Role));
                await userManager.AddToRoleAsync(newUser, account.Role);
                return new GeneralServiceResponse(200, "Account created");
            }
            else
            {
                await userManager.AddToRoleAsync(newUser, account.Role);
                return new GeneralServiceResponse(200, "Account created");

            }
        }

        public async Task<AccountServiceResponse> RefreshToken(AccountToken accountToken)
        {
            var principal = GetPrincipalFromExpiredToken(accountToken.AccessToken);
            if (principal == null) return new AccountServiceResponse(401, null, null, "Invalid token");
            var user = await userManager.FindByNameAsync(principal.Identity.Name);
            Console.WriteLine("RefreshToken from clint " + accountToken.RefreshToken);
            Console.WriteLine("Saved RefreshToken " + user.RefreshToken);
            Console.WriteLine("user " + user);
            if (user == null || user.RefreshToken != accountToken.RefreshToken)
                return new AccountServiceResponse(401, null, null, "Cannot find user");

            if (user.RefreshTokenExpiryTime <= DateTime.Now) return new AccountServiceResponse(401, null, null, "Refresh Token expired");

            string newAccessToken = GenerateJwtToken(principal.Claims);
            string newRefreshToken = GenerateRefreshToken();

            user.RefreshToken = newRefreshToken;
            _ = int.TryParse(config["JWT:RefreshTokenValidityInDays"], out int refreshTokenValidityInDays);
            user.RefreshTokenExpiryTime = DateTime.Now.AddDays(refreshTokenValidityInDays);

            // Console.WriteLine("User +++++++++" + user.RefreshToken);

            var result = await userManager.UpdateAsync(user);
            // Console.WriteLine("Result +++++++++" + result);
            if (!result.Succeeded) return new AccountServiceResponse(401, accountToken.AccessToken, accountToken.RefreshToken, "Token not refreshed");

            Console.WriteLine("New Token " + newRefreshToken);

            return new AccountServiceResponse(200, newAccessToken, newRefreshToken, "Token refreshed");
        }

        public async Task<GeneralServiceResponse> Logout(AccountToken accountToken)
        {
            if (accountToken == null) return new GeneralServiceResponse(401, "Account is null");

            var principal = GetPrincipalFromExpiredToken(accountToken.AccessToken);
            if (principal == null) return new GeneralServiceResponse(401, "Invalid token");

            var username = principal.Identity.Name;
            var user = await userManager.FindByNameAsync(username);
            if (user == null) return new GeneralServiceResponse(401, "User not found");

            user.RefreshToken = null;
            user.RefreshTokenExpiryTime = DateTime.Now;
            await userManager.UpdateAsync(user);

            return new GeneralServiceResponse(200, "Logout successful");

        }

        //Change user password
        public async Task<GeneralServiceResponse> ChangePassword(AccountChangePassword accountChangePassword)
        {
            if (accountChangePassword == null) return new GeneralServiceResponse(401, "Account is null");

            if (accountChangePassword.accessToken == null) return new GeneralServiceResponse(401, "Token is null");

            var principal = GetPrincipalFromExpiredToken(accountChangePassword.accessToken);
            if (principal == null) return new GeneralServiceResponse(401, "Invalid token");


            var user = await userManager.FindByNameAsync(principal.Identity.Name);
            if (user == null) return new GeneralServiceResponse(401, "User not found");

            var result = await userManager.ChangePasswordAsync(user, accountChangePassword.OldPassword, accountChangePassword.NewPassword);
            if (!result.Succeeded) return new GeneralServiceResponse(401, "Password not changed");

            return new GeneralServiceResponse(200, "Password changed");
        }

        public async Task<GeneralServiceResponse> InactiveUser(string[] eamil)
        {
            if (eamil == null) return await Task.FromResult(new GeneralServiceResponse(401, "Email is null"));

            foreach (var email in eamil)
            {
                var user = await userManager.FindByEmailAsync(email);
                if (user == null) return await Task.FromResult(new GeneralServiceResponse(401, "User not found"));

                user.IsActive = false;
                await userManager.UpdateAsync(user);
            }

            return await Task.FromResult(new GeneralServiceResponse(200, "User inactive"));
        }

        public async Task<GeneralServiceResponse> GetUserRole(string accountToken)
        {
            if (accountToken == null) return new GeneralServiceResponse(401, "Account is null");

            var principal = GetPrincipalFromExpiredToken(accountToken);
            if (principal == null) return new GeneralServiceResponse(401, "Invalid token");

            var username = principal.Identity.Name;
            var user = await userManager.FindByNameAsync(username);
            if (user == null) return new GeneralServiceResponse(401, "User not found");

            var userRoles = await userManager.GetRolesAsync(user);

            return new GeneralServiceResponse(200, userRoles[0].ToString());
        }
        public Task<GeneralServiceResponse> ActiveUser(string[] eamil)
        {
            throw new NotImplementedException();
        }

        private string GenerateJwtToken(IEnumerable<Claim> claims)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            // var claims = new[]
            // {
            //     new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            //     new Claim(ClaimTypes.Name, user.Username),
            //     new Claim(ClaimTypes.Email, user.Email),
            //     new Claim(ClaimTypes.Role, user.Role)
            // };
            _ = int.TryParse(config["JWT:TokenValidityInMinutes"], out int tokenValidityInMinutes);
            var token = new JwtSecurityToken(
                config["Jwt:Issuer"],
                config["Jwt:Audience"],
                claims: claims,
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

        public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
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