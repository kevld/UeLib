using UeLib.Data.Models;

namespace UeLib.Data.DTO
{
    public class TagDTO
    {

        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public TagDTO()
        {
        }

        public TagDTO(Tag tag)
        {
            Id = tag.Id;
            Name = tag.Name;
        }

        public TagDTO(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public Tag ToTag()
        {
            return new Tag()
            {
                Id = Id,
                Name = Name,
                AssetTags = new List<AssetTag>()
            };
        }

        public override string ToString()
        {
            return $"{Id}-{Name}";
        }

        public override bool Equals(object? obj)
        {
            var other = obj as TagDTO;
            if (other == null)
                return false;

            return this.ToString() == other.ToString();
        }
    }
}
