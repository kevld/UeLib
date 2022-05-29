using UeLib.Data.Models;

namespace UeLib.Data.DTO
{
    public class ProjectDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public IEnumerable<RankedAssetDTO> RankedAssets { get; set; }

        public ProjectDTO()
        {
            RankedAssets = new HashSet<RankedAssetDTO>();
        }

        public ProjectDTO(Project project)
        {
            Id = project.Id;
            Name = project.Name;
            Description = project.Description;
            RankedAssets = new HashSet<RankedAssetDTO>();
        }

        public Project ToNewProject()
        {
            return new Project()
            {
                Name = Name,
                Description = Description,
            };
        }

        public override bool Equals(object? obj)
        {
            var other = obj as ProjectDTO;
            if (other == null)
                return false;

            string stringRA = string.Join(",", RankedAssets.Select(x => x.ToString()));
            string otherStringRA = string.Join(",", other.RankedAssets.Select(x => x.ToString()));

            return Name == other.Name
                && Description == other.Description
                && Id == other.Id
                && stringRA == otherStringRA;
        }
    }
}
