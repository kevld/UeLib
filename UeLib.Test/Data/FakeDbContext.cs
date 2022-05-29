
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using UeLib.Data;
using UeLib.Data.DTO;
using UeLib.Data.Models;

namespace UeLib.Test.Data
{
    internal class FakeDbContext
    {


        internal readonly UeLibContext Context;

        private TagDTO t1, t2, t3, t4;
        private AssetDTO a1, a2, a3, a4;
        private ProjectDTO p1, p2, p3, p4;
        private RankedAssetDTO ra1, ra2, ra3, ra4, raP1ra1;
        private PostRankedAssetDTO pra1;

        internal FakeDbContext()
        {
            var options = new DbContextOptionsBuilder<UeLibContext>()
            .UseInMemoryDatabase(databaseName: "FakeDbContext")
            .Options;

            Context = new UeLibContext(options);

            InitDb();
            InitDtoResults();
        }

        void InitDb()
        {
            Context.Database.EnsureCreated();

            Asset? asset = Context.Assets.FirstOrDefault();
            if (asset != null)
                return;

            List<Tag> tags = new List<Tag>()
            {
                new Tag() { Id = 1, Name = "Tag1"},
                new Tag() { Id = 2, Name = "Tag2"},
                new Tag() { Id = 3, Name = "Tag3"},
            };

            List<Asset> assets = new List<Asset>()
            {
                new Asset() { Id = 1, Name = "Asset1", Description = "Description1", AssetType = Enums.AssetType.Asset, Url="Url", MinVersion=4.27F, MaxVersion=4.28F},
                new Asset() { Id = 2, Name = "Asset2", Description = "Description2", AssetType = Enums.AssetType.EnginePugin, Url="Url", MinVersion=4.27F},
                new Asset() { Id = 3, Name = "Asset3", Description = "Description3", AssetType = Enums.AssetType.FullProject, Url="Url", MinVersion=4.27F},
            };

            List<Project> projects = new List<Project>()
            {
                new Project() { Id=1, Name = "Project1", Description="Description1"},
                new Project() { Id=2, Name = "Project2", Description="Description2"},
                new Project() { Id=3, Name = "Project3", Description="Description3"},
            };

            List<AssetTag> assetTags = new List<AssetTag>()
            {
                new AssetTag() { AssetId = 1, TagId = 1},
                new AssetTag() { AssetId = 1, TagId = 2},
                new AssetTag() { AssetId = 2, TagId = 2},
                new AssetTag() { AssetId = 2, TagId = 3},
            };

            List<RankedAsset> rankedAssets = new List<RankedAsset>()
            {
                new RankedAsset() { Id = 1, AssetId = 1, ProjectId=1, Rank = 9},
                new RankedAsset() { Id = 2, AssetId = 2, ProjectId=1, Rank = 5},
                new RankedAsset() { Id = 3, AssetId = 2, ProjectId=2, Rank = 1},
            };

            Context.Tags.AddRange(tags);
            Context.Assets.AddRange(assets);
            Context.Projects.AddRange(projects);
            Context.AssetTags.AddRange(assetTags);
            Context.RankedAssets.AddRange(rankedAssets);

            Context.SaveChanges();
        }

        void InitDtoResults()
        {
            t1 = new TagDTO() { Id = 1, Name = "Tag1" };
            t2 = new TagDTO() { Id = 2, Name = "Tag2" };
            t3 = new TagDTO() { Id = 3, Name = "Tag3" };
            t4 = new TagDTO() { Id = 4, Name = "Tag4" };

            a1 = new AssetDTO() { Id = 1, Name = "Asset1", Description = "Description1", AssetType = Enums.AssetType.Asset, Url = "Url", MinVersion = 4.27F, MaxVersion = 4.28F, Tags = new List<TagDTO>() { t1, t2 } };
            a2 = new AssetDTO() { Id = 2, Name = "Asset2", Description = "Description2", AssetType = Enums.AssetType.EnginePugin, Url = "Url", MinVersion = 4.27F, Tags = new List<TagDTO>() { t2, t3 } };
            a3 = new AssetDTO() { Id = 3, Name = "Asset3", Description = "Description3", AssetType = Enums.AssetType.FullProject, Url = "Url", MinVersion = 4.27F };
            a4 = new AssetDTO() { Id = 4, Name = "Asset4", Description = "Description4", AssetType = Enums.AssetType.Asset, Url = "Url", MinVersion = 4.27F, MaxVersion = 5F, Tags = new List<TagDTO>() { t1, t2, t3 } };

            p1 = new ProjectDTO() { Id = 1, Name = "Project1", Description = "Description1" };
            p2 = new ProjectDTO() { Id = 2, Name = "Project2", Description = "Description2" };
            p3 = new ProjectDTO() { Id = 3, Name = "Project3", Description = "Description3" };
            p4 = new ProjectDTO() { Id = 4, Name = "Project4", Description = "Description4" };

            ra1 = new RankedAssetDTO() { Id = 1, AssetId = 1, AssetName = "Asset1", Rank = 9 };
            ra2 = new RankedAssetDTO() { Id = 2, AssetId = 2, AssetName = "Asset2", Rank = 5 };
            ra3 = new RankedAssetDTO() { Id = 3, AssetId = 2, AssetName = "Asset2", Rank = 1 };
            ra4 = new RankedAssetDTO() { Id = 4, AssetId = 3, AssetName = "Asset3", Rank = 3 };
            raP1ra1 = new RankedAssetDTO() { AssetId = 3, AssetName = "Asset3", Rank = 0 };


            pra1 = new PostRankedAssetDTO() { AssetId = 3, ProjectId = 1, Rank = 3 };
        }

        ~FakeDbContext()
        {
            Context.Dispose();
        }

        internal void Reset()
        {
            var ra = Context.RankedAssets.ToList();
            var at = Context.AssetTags.ToList();
            var a = Context.Assets.ToList();
            var t = Context.Tags.ToList();
            var p = Context.Projects.ToList();

            Context.RankedAssets.RemoveRange(ra);
            Context.AssetTags.RemoveRange(at);
            Context.Assets.RemoveRange(a);
            Context.Tags.RemoveRange(t);
            Context.Projects.RemoveRange(p);

            Context.SaveChanges();

            InitDb();
        }

        internal List<AssetDTO> ExpectedResultOf_AssetsController_GetAll() => new List<AssetDTO>() { a1, a2, a3 };

        internal AssetDTO ExpectedResultOf_AssetsController_GetById()
        {
            var result = a1;
            result.Tags = new List<TagDTO>() { t1, t2 };

            return result;
        }

        internal AssetDTO Seed_AssetsController_PostAsset() => a4;
        internal AssetDTO ExpectedResultOf_AssetsController_Post() => a4;

        internal List<ProjectDTO> ExpectedResultOf_ProjectsController_GetAll() => new List<ProjectDTO>() { p1, p2, p3 };

        internal ProjectDTO ExpectedResultOf_ProjectsController_PostProject() => p4;

        internal ProjectDTO Seed_ProjectsController_PostAsset() => p4;

        internal List<TagDTO> ExpectedResultOf_TagsController_GetAll() => new List<TagDTO>() { t1, t2, t3 };

        internal TagDTO ExpectedResultOf_TagsController_GetById() => t1;

        internal TagDTO ExpectedResultOf_TagsController_PostTag() => t4;

        internal TagDTO Seed_TagsController_Post() => t4;

        internal List<RankedAssetDTO> ExpectedResultOf_RankedAssetsController_GetRankedAsset() => new List<RankedAssetDTO>() { ra1, ra2, raP1ra1 };

        internal PostRankedAssetDTO Seed_RankedAssetsController_PostAsset() => pra1;

        internal RankedAssetDTO ExpectedResultOf_RankedAssetsController_Post() => ra4;
    }
}
