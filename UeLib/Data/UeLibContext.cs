using Microsoft.EntityFrameworkCore;
using UeLib.Data.Models;

namespace UeLib.Data
{
    public class UeLibContext : DbContext
    {
        public DbSet<Asset> Assets => Set<Asset>();
        public DbSet<AssetTag> AssetTags => Set<AssetTag>();
        public DbSet<Project> Projects => Set<Project>();
        public DbSet<RankedAsset> RankedAssets => Set<RankedAsset>();
        public DbSet<Tag> Tags => Set<Tag>();


        public UeLibContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AssetTagEntityTypeConfiguration());
        }

    }
}
