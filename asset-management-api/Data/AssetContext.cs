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
        public DbSet<SubZone> SubZone { get; set; }
    }
}