using AssetManagement.Dtos;
using AssetManagement.Models;
using static AssetManagement.Dtos.ServiceResponses;

namespace AssetManagement.Data
{
    public interface IAccountRepo
    {
        Task<AccountServiceResponse> Login(AccountLoginDto account);
        Task<GeneralServiceResponse> Register(AccountModel account);
        Task<AccountServiceResponse> RefreshToken(AccountToken accountToken);
    }
}