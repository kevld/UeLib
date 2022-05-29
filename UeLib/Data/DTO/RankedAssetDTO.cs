using UeLib.Data.Models;

namespace UeLib.Data.DTO
{
    public class RankedAssetDTO
    {
        public int? Id { get; set; }
        public int AssetId { get; set; }
        public string AssetName { get; set; } = null!;
        public float Rank { get; set; }

        public RankedAssetDTO()
        {

        }

        public override string ToString()
        {
            return $"{AssetId}-{AssetName}-{Rank}";
        }

        public override bool Equals(object? obj)
        {
            var other = obj as RankedAssetDTO;
            if (other == null)
                return false;

            return this.ToString() == other.ToString();
        }
    }
}
