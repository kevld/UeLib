using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UeLib.Data.Models
{
    public class Project
    {
        public Project()
        {
            RankedAssets = new List<RankedAsset>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public List<RankedAsset> RankedAssets { get; set; }

        public override bool Equals(object? obj)
        {
            var other = obj as Project;
            if (other == null)
                return false;

            string strRa = string.Join(",", RankedAssets.Select(x => $"{x.ProjectId}-{x.AssetId}-{x.Rank}"));
            string strOtherRa = string.Join(",", other.RankedAssets.Select(x => $"{x.ProjectId}-{x.AssetId}-{x.Rank}"));

            return other.Id == Id && other.Name == Name && other.Description == Description && strOtherRa == strRa;
        }
    }

    public class ProjectEntityTypeConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder
            .Property(f => f.Id)
            .ValueGeneratedOnAdd();
        }
    }
}
