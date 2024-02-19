using AssetManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace AssetManagement.Data
{
    public class AssetContext : DbContext
    {
        public AssetContext(DbContextOptions<AssetContext> opt) : base(opt)
        {
            
        }

        public DbSet<AssetManage> Assets { get; set; }

        public DbSet<AccountModel> Accounts { get; set; }
    }
}