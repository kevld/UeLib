using UeLib.Data.Models;

namespace UeLib.Data.DTO
{
    public class PostRankedAssetDTO
    {
        public int AssetId { get; set; }

        public int ProjectId { get; set; }

        public float Rank { get; set; }

        public RankedAsset ToRankedAsset()
        {
            return new RankedAsset()
            {
                AssetId = AssetId,
                ProjectId = ProjectId,
                Rank = Rank
            };
        }
    }
}
