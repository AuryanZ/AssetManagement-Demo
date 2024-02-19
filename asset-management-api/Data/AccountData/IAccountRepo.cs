using AssetManagement.Models;

namespace AssetManagement.Data
{
    public interface IAccountRepo
    {
        bool SaveChanges();
        void CreateUser(AccountModel account);
        AccountModel GetUserById(int id);
        AccountModel GetUserByUserName(string userName);
        void UpdateUser(AccountModel account);
        void DeleteUser(AccountModel account);
        AccountModel GetUserByEmail(string email);
        void UpdateUserLastLogin(AccountModel account);
    }
}