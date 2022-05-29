using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UeLib.Enums;

namespace UeLib.Data.Models
{
    public class Asset
    {
        public Asset()
        {
            AssetTags = new HashSet<AssetTag>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string Url { get; set; } = null!;

        public float MinVersion { get; set; }

        public float? MaxVersion { get; set; }

        public AssetType AssetType { get; set; }

        public virtual ICollection<AssetTag> AssetTags { get; set; }

        //public List<Tag> Tags { get; set; }

        public override bool Equals(object? obj)
        {
            var other = obj as Asset;
            if (other == null)
                return false;

            string stringTags = string.Join(",", AssetTags.Select(x => $"{x.AssetId}-{x.TagId}"));
            string otherStringTags = string.Join(",", other.AssetTags.Select(x => $"{x.AssetId}-{x.TagId}"));

            return Name == other.Name
                && Description == other.Description
                && Id == other.Id
                && Url == other.Url
                && MinVersion == other.MinVersion
                && MaxVersion == other.MaxVersion
                && AssetType == other.AssetType
                && stringTags == otherStringTags;
        }
    }

    public class AssetEntityTypeConfiguration : IEntityTypeConfiguration<Asset>
    {
        public void Configure(EntityTypeBuilder<Asset> builder)
        {
            builder
            .Property(f => f.Id)
            .ValueGeneratedOnAdd();
        }
    }
}
