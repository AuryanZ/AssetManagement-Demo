using System.Security.Claims;
using AssetManagement.Dtos;
using AssetManagement.Models;

namespace AssetManagement.Data
{
    public interface IAccountRepo
    {
        Task<AccountServiceResponse> Login(AccountLoginDto account);
        Task<GeneralServiceResponse> Register(AccountModel account);
        Task<AccountServiceResponse> RefreshToken(AccountToken accountToken);
        Task<GeneralServiceResponse> Logout(AccountToken accountToken);
        Task<GeneralServiceResponse> ChangePassword(AccountChangePassword accountChangePassword);
        Task<GeneralServiceResponse> InactiveUser(string[] eamil);
        Task<GeneralServiceResponse> ActiveUser(string[] eamil);
        Task<GeneralServiceResponse> GetUserRole(string accountToken);
        public ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }

}