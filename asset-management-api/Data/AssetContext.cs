using AssetManagement.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AssetManagement.Data
{
    public class AssetContext(DbContextOptions<AssetContext> options) : IdentityDbContext<AppUser>(options)
    {

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Asset> Assets { get; set; }
        public DbSet<AssetsGroup> AssetsGroup { get; set; }
        public DbSet<BatteryBank> BatteryBank { get; set; }
        public DbSet<Cable> Cable { get; set; }
        public DbSet<Substation> Substation { get; set; }
        public DbSet<SubZone> SubZone { get; set; }
        public DbSet<Transformer> Transformer { get; set; }
        // public DbSet<Feeder> Feeder { get; set; }
    }
}