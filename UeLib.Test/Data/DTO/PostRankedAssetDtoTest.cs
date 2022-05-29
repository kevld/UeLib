using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UeLib.Data.DTO;
using UeLib.Data.Models;

namespace UeLib.Test.Data.DTO
{
    [TestClass]
    public class PostRankedAssetDtoTest
    {
        [TestMethod]
        public void ToRankedAssetTest()
        {
            // Arrange
            PostRankedAssetDTO rankedAssetDTO = new PostRankedAssetDTO()
            {
                ProjectId = 1,
                AssetId = 1,
                Rank = 9
            };

            RankedAsset expectedResult = new RankedAsset()
            {
                AssetId = 1,
                ProjectId = 1,
                Rank = 9
            };

            // Act
            RankedAsset result = rankedAssetDTO.ToRankedAsset();

            // Assert
            Assert.AreEqual(expectedResult, result);
            Assert.AreNotEqual(null, result);
        }
    }
}

