using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace UeLib.Data.Models
{
    public class AssetTag
    {
        public int AssetId { get; set; }
        public Asset Asset { get; set; } = null!;
        public int TagId { get; set; }
        public Tag Tag { get; set; } = null!;

    }

    public class AssetTagEntityTypeConfiguration : IEntityTypeConfiguration<AssetTag>
    {
        public void Configure(EntityTypeBuilder<AssetTag> builder)
        {
            builder.HasKey(x => new { x.AssetId, x.TagId });
            builder.HasOne(x => x.Asset)
                   .WithMany(x => x.AssetTags)
                   .HasForeignKey(x => x.AssetId);
            builder.HasOne(x => x.Tag)
                   .WithMany(x => x.AssetTags)
                   .HasForeignKey(x => x.TagId);
        }
    }
}
