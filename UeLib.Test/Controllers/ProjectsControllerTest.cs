using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UeLib.Controllers;
using UeLib.Data.DTO;
using UeLib.Test.Data;

namespace UeLib.Test.Controllers
{
    [TestClass]
    public class ProjectsControllerTest
    {
        private readonly FakeDbContext _fakeDbContext;

        public ProjectsControllerTest()
        {
            _fakeDbContext = new FakeDbContext();
            _fakeDbContext.Reset();
        }

        [TestMethod]
        public async Task ProjectsController_Get()
        {
            // Arrange
            ProjectsController controller = new ProjectsController(_fakeDbContext.Context);
            List<ProjectDTO> expectedResult = _fakeDbContext.ExpectedResultOf_ProjectsController_GetAll();

            // Act
            IEnumerable<ProjectDTO> request = await controller.GetProjects();
            List<ProjectDTO> result = request.ToList();

            // Assert

            Assert.AreEqual(expectedResult.Count, result.Count);

            for (int i = 0; i < result.Count; i++)
            {
                Assert.AreEqual(expectedResult[i], result[i]);
            }
        }

        [TestMethod]
        public async Task AssetsController_Post()
        {
            // Arrange
            ProjectsController controller = new ProjectsController(_fakeDbContext.Context);
            ProjectDTO projectDto = _fakeDbContext.Seed_ProjectsController_PostAsset();
            ProjectDTO expectedResult = _fakeDbContext.ExpectedResultOf_ProjectsController_PostProject();

            // Act
            var request = (dynamic)await controller.PostProject(projectDto);
            var result = request.Result.Value;

            // Assert
            Assert.AreEqual(_fakeDbContext.Context.Projects.Count(), 4);
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public async Task DeleteProject_Delete()
        {
            // Arrange
            ProjectsController controller = new ProjectsController(_fakeDbContext.Context);

            // Act
            await controller.DeleteProject(4);
            var result = _fakeDbContext.Context.Projects.FirstOrDefault(x => x.Id == 4);

            // Assert
            Assert.AreEqual(null, result);


        }
    }
}
