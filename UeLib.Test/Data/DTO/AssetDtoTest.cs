using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UeLib.Data.DTO;
using UeLib.Data.Models;
using UeLib.Enums;

namespace UeLib.Test.Data.DTO
{
    [TestClass]
    public class AssetDtoTest
    {
        [TestMethod]
        public void Ctor_From_Asset()
        {
            // Arrange
            List<Tag> tags = new List<Tag>()
            {
                new Tag() { Name = "Tag1", Id =1},
                new Tag() { Name = "Tag2", Id =2},
            };

            Asset asset = new Asset()
            {
                Id = 1,
                Name = "Name",
                Description = "Description",
                Url = "Url",
                MinVersion = 4.27F,
                AssetType = AssetType.Asset,
                AssetTags = new List<AssetTag>()
                {
                    new AssetTag() { AssetId = 1, TagId = 1, Tag = tags[0] },
                    new AssetTag() { AssetId = 1, TagId = 2, Tag = tags[1] },
                }
            };

            AssetDTO expectedResult = new AssetDTO()
            {
                Id = 1,
                Name = "Name",
                Description = "Description",
                Url = "Url",
                MinVersion = 4.27F,
                AssetType = AssetType.Asset,
                Tags = new List<TagDTO>()
                {
                    new TagDTO() { Id = 1, Name = "Tag1"},
                    new TagDTO() { Id = 2, Name = "Tag2"},
                }
            };

            // Act
            AssetDTO assetDTO = new AssetDTO(asset);

            // Assert 
            Assert.AreEqual(expectedResult, assetDTO);
            Assert.AreNotEqual(null, assetDTO);
        }

        [TestMethod]
        public void ToNewAsset_Test()
        {
            // Arrange
            List<Tag> tags = new List<Tag>()
            {
                new Tag() { Name = "Tag1", Id = 1},
                new Tag() { Name = "Tag2", Id = 2},
            };

            AssetDTO assetDTO = new AssetDTO()
            {
                Name = "Name",
                Description = "Description",
                Url = "Url",
                MinVersion = 4.27F,
                AssetType = AssetType.Asset,
                Tags = new List<TagDTO>()
                {
                    new TagDTO() { Id = 1, Name = "Tag1"},
                    new TagDTO() { Id = 2, Name = "Tag2"},
                }
            };

            Asset expectedResult = new Asset()
            {
                Name = "Name",
                Description = "Description",
                Url = "Url",
                MinVersion = 4.27F,
                AssetType = AssetType.Asset,
                AssetTags = new HashSet<AssetTag>()
            };

            // Act
            Asset asset = assetDTO.ToNewAsset();

            // Assert
            Assert.AreEqual(expectedResult, asset);
            Assert.AreNotEqual(null, asset);
        }
    }
}
