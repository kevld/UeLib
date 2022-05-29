using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace UeLib.Data.Models
{
    public class RankedAsset
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, NotNull]
        public int AssetId { get; set; }

        public Asset Asset { get; set; } = null!;

        [Required]
        public float Rank { get; set; }

        [Required, NotNull]
        public int ProjectId { get; set; }
        public Project Project { get; set; } = null!;

        public override bool Equals(object? obj)
        {
            var other = obj as RankedAsset;
            if (other == null)
                return false;

            return AssetId == other.AssetId
                && ProjectId == other.ProjectId
                && Rank == other.Rank;
        }
    }

    public class RankedAssetEntityTypeConfiguration : IEntityTypeConfiguration<RankedAsset>
    {
        public void Configure(EntityTypeBuilder<RankedAsset> builder)
        {
            builder
            .Property(f => f.Id)
            .ValueGeneratedOnAdd();

        }
    }
}
