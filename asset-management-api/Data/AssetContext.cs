using AssetManagement.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AssetManagement.Data
{
    public class AssetContext(DbContextOptions<AssetContext> options) : IdentityDbContext<AppUser>(options)
    {
        public DbSet<Asset> Assets { get; set; }
        public DbSet<ZoneSubstation> ZoneSubstations { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Asset>().UseTpcMappingStrategy();
            modelBuilder.Entity<Transformer>().ToTable("Transformer");
            modelBuilder.Entity<BatteryBank>().ToTable("BatteryBank");
            modelBuilder.Entity<Switch>().ToTable("Switch");
            modelBuilder.Entity<VotatgeRegulator>().ToTable("VotatgeRegulator");
        }
    }
}