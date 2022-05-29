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
    public class TagDtoTest
    {
        [TestMethod]
        public void CtorFromTag()
        {
            // Arrange
            Tag tag = new Tag()
            {
                Id = 1,
                Name = "Name",
            };

            TagDTO expectedResult = new TagDTO()
            {
                Id = 1,
                Name = "Name",
            };

            // Act
            TagDTO actualResult = new TagDTO(tag);

            // Assert
            Assert.AreEqual(expectedResult.ToString(), actualResult.ToString());
        }

        [TestMethod]
        public void ToTagTest()
        {
            // Arrange
            TagDTO t = new TagDTO()
            {
                Id = 1,
                Name = "Name",
            };

            Tag expectedResult = new Tag()
            {
                Id = 1,
                Name = "Name",
                AssetTags = new List<AssetTag>()
            };

            // Act
            Tag actualResult = t.ToTag();

            // Assert
            Assert.AreEqual(expectedResult.ToString(), actualResult.ToString());
        }

        [TestMethod]
        public void EqualsNull()
        {
            // Arrange
            TagDTO tag = new TagDTO()
            {
                Id = 1,
                Name = "Name",
            };
            TagDTO tagDTO2 = null;

            Assert.AreEqual(false, tag.Equals(tagDTO2));
        }

        [TestMethod]
        public void CtorWithParams()
        {
            // Arrange
            TagDTO tag = new TagDTO(1, "Name");
            
            TagDTO expectedResult = new TagDTO()
            {
                Id = 1,
                Name = "Name",
            };


            Assert.AreEqual(expectedResult, tag);
        }
    }
}
