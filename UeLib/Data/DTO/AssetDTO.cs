using UeLib.Data.Models;
using UeLib.Enums;

namespace UeLib.Data.DTO
{
    public class AssetDTO
    {


        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string Url { get; set; } = null!;

        public float MinVersion { get; set; }

        public float? MaxVersion { get; set; }

        public AssetType AssetType { get; set; }

        public IEnumerable<TagDTO> Tags { get; set; }

        public AssetDTO()
        {
            Tags = new HashSet<TagDTO>();
        }

        public AssetDTO(Asset asset)
        {
            Id = asset.Id;
            Name = asset.Name;
            Description = asset.Description;
            Url = asset.Url;
            MinVersion = asset.MinVersion;
            MaxVersion = asset.MaxVersion;
            AssetType = asset.AssetType;
            Tags = asset.AssetTags.Select(x => new TagDTO(x.Tag)).ToList();
        }

        public Asset ToNewAsset()
        {
            return new Asset()
            {
                Name = Name,
                Description = Description,
                Url = Url,
                MinVersion = MinVersion,
                MaxVersion = MaxVersion,
                AssetType = AssetType,
            };
        }

        public override bool Equals(object? obj)
        {
            var other = obj as AssetDTO;
            if (other == null)
                return false;

            string stringTags = string.Join(",", Tags.Select(x => x.ToString()));
            string otherStringTags = string.Join(",", other.Tags.Select(x => x.ToString()));

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
}
