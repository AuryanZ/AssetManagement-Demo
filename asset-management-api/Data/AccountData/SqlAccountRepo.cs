using AssetManagement.Models;

namespace AssetManagement.Data
{
    public class SqlAccountRepo : IAccountRepo
    {
        private readonly AssetContext _context;

        public SqlAccountRepo(AssetContext context)
        {
            _context = context;
        }
        public void CreateUser(AccountModel account)
        {
            if (account == null)
            {
                throw new ArgumentNullException(nameof(account));
            }
            _context.Accounts.Add(account);
        }

        public void DeleteUser(AccountModel account)
        {
            if (account == null)
            {
                throw new ArgumentNullException(nameof(account));
            }
            _context.Accounts.Remove(account);
        }

        public AccountModel GetUserById(int id)
        {
            return _context.Accounts.FirstOrDefault(p => p.Id == id);
        }

        public AccountModel GetUserByUserName(string userName)
        {
            return _context.Accounts.FirstOrDefault(p => p.Username == userName);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateUser(AccountModel account)
        {
            //Nothing
        }

        AccountModel IAccountRepo.GetUserById(int id)
        {
            return _context.Accounts.FirstOrDefault(p => p.Id == id);
        }

        AccountModel IAccountRepo.GetUserByUserName(string userName)
        {
            return _context.Accounts.FirstOrDefault(p => p.Username == userName);
        }

        AccountModel IAccountRepo.GetUserByEmail(string email)
        {
            return _context.Accounts.FirstOrDefault(p => p.Email == email);
        }

        public void UpdateUserLastLogin(AccountModel account)
        {
            // Nothing
        }
    }
}