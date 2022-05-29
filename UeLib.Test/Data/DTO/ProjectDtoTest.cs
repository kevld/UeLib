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
    public class ProjectDtoTest
    {
        [TestMethod]
        public void Ctor_From_Project()
        {
            // Arrange
            Project project = new Project()
            {
                Id = 1,
                Name = "Name",
                Description = "Description",
                RankedAssets = new List<RankedAsset>()
            };

            ProjectDTO expectedResult = new ProjectDTO()
            {
                Id = 1,
                Name = "Name",
                Description = "Description",
                RankedAssets = new HashSet<RankedAssetDTO>()
            };

            // Act
            ProjectDTO actualResult = new ProjectDTO(project);
            
            // Assert
            Assert.AreEqual(expectedResult, actualResult);
            Assert.AreNotEqual(null, actualResult);
        }

        [TestMethod]
        public void ToNewProjectTest()
        {
            // Arrange
            ProjectDTO projectDTO = new ProjectDTO()
            {
                Name = "Name",
                Description = "Description",
            };

            Project expectedResult = new Project()
            {
                Name = "Name",
                Description = "Description",
            };

            // Act
            Project actualResult = projectDTO.ToNewProject();

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void EqualsNull()
        {
            // Arrange
            ProjectDTO projectDTO = new ProjectDTO()
            {
                Name = "Name",
                Description = "Description",
            };
            ProjectDTO projectDTO2 = null;

            Assert.AreEqual(false, projectDTO.Equals(projectDTO2));
        }
    }
}
