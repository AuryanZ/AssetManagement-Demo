using AssetManagement.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AssetManagement.Data
{
    public class AssetContext(DbContextOptions<AssetContext> options) : IdentityDbContext<AppUser>(options)
    {
        public DbSet<Asset> Assets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<Asset>().ToTable("Asset", tb => tb.Property(e => e.AssetId).UseIdentityColumn(1, 1));
            // modelBuilder.Entity<Transformer>().ToTable("Transformer", tb => tb.Property(e => e.AssetId).UseIdentityColumn(1, 2));
            // modelBuilder.Entity<BatteryBank>().ToTable("BatteryBank", tb => tb.Property(e => e.AssetId).UseIdentityColumn(2, 2));
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Asset>().UseTpcMappingStrategy();
            modelBuilder.Entity<Transformer>().ToTable("Transformer");
            modelBuilder.Entity<BatteryBank>().ToTable("BatteryBank");
        }
        // public DbSet<AssetsGroup> AssetsGroup { get; set; }
        // public DbSet<Transformer> Transformer { get; set; }
        // public DbSet<BatteryBank> BatteryBank { get; set; }
        // public DbSet<Cable> Cable { get; set; }
        // public DbSet<Substation> Substation { get; set; }
        // public DbSet<SubZone> SubZone { get; set; }
        // public DbSet<PillerBox> PillerBox { get; set; }
        // public DbSet<Pole> Pole { get; set; }
        // public DbSet<Feeder> Feeder { get; set; }
    }
}