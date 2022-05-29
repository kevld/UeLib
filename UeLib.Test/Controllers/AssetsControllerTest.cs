using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UeLib.Controllers;
using UeLib.Data.DTO;
using UeLib.Data.Models;
using UeLib.Test.Data;

namespace UeLib.Test.Controllers
{
    [TestClass]
    public class AssetsControllerTest
    {

        private readonly FakeDbContext _fakeDbContext;

        public AssetsControllerTest()
        {
            _fakeDbContext = new FakeDbContext();
            _fakeDbContext.Reset();
        }

        [TestMethod]
        public async Task AssetsController_Get()
        {
            // Arrange
            AssetsController controller = new AssetsController(_fakeDbContext.Context);
            List<AssetDTO> expectedResult = _fakeDbContext.ExpectedResultOf_AssetsController_GetAll();

            // Act
            IEnumerable<AssetDTO> request = await controller.GetAssets();
            List<AssetDTO> result = request.ToList();

            // Assert
            Assert.AreEqual(expectedResult.Count, result.Count);

            for (int i = 0; i < result.Count; i++)
            {
                bool isequal = expectedResult[i].Equals(result[i]);
                Assert.AreEqual(expectedResult[i], result[i]);
            }
        }

        [TestMethod]
        public async Task AssetsController_GetById()
        {
            // Arrange
            AssetsController controller = new AssetsController(_fakeDbContext.Context);
            AssetDTO expectedResult = _fakeDbContext.ExpectedResultOf_AssetsController_GetById();

            // Act
            var request = await controller.GetAsset(1);
            AssetDTO? result = request.Value;

            // Assert
            Assert.AreEqual(expectedResult, result);

            // Act
            request = await controller.GetAsset(10);
            result = request.Value;

            // Assert
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        public async Task AssetsController_Post()
        {
            // Arrange
            AssetsController controller = new AssetsController(_fakeDbContext.Context);
            AssetDTO assetDTO = _fakeDbContext.Seed_AssetsController_PostAsset();
            AssetDTO expectedResult = _fakeDbContext.ExpectedResultOf_AssetsController_Post();

            // Act
            var request = (dynamic)await controller.PostAsset(assetDTO);
            var result = request.Result.Value;

            // Assert
            Assert.AreEqual(_fakeDbContext.Context.Assets.Count(), 4);
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public async Task AssetsController_Delete()
        {
            // Arrange
            AssetsController controller = new AssetsController(_fakeDbContext.Context);

            // Act
            await controller.DeleteAsset(4);
            var result = _fakeDbContext.Context.Assets.FirstOrDefault(x => x.Id == 4);

            // Assert
            Assert.AreEqual(null, result);
        }
    }
}
