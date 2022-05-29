using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UeLib.Data.DTO;

namespace UeLib.Test.Data.DTO
{
    [TestClass]
    public class RankedAssetDtoTest
    {
        [TestMethod]
        public void ToStringTest()
        {
            // Arrange
            RankedAssetDTO rankedAssetDTO = new RankedAssetDTO()
            {
                Id = 1,
                AssetId = 1,
                AssetName = "AssetName",
                Rank = 9
            };

            string expectedResult = "1-AssetName-9";

            // Act
            string actualResult = rankedAssetDTO.ToString();

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }


        [TestMethod]
        public void EqualsNull()
        {
            // Arrange
            RankedAssetDTO rankedAssetDTO = new RankedAssetDTO()
            {
                Id = 1,
                AssetId = 1,
                AssetName = "AssetName",
                Rank = 9
            };
            RankedAssetDTO rankedAssetDTO2 = null;

            Assert.AreEqual(false, rankedAssetDTO.Equals(rankedAssetDTO2));
        }
    }
}
