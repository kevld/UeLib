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
    public class RankedAssetsControllerTest
    {
        private readonly FakeDbContext _fakeDbContext;

        public RankedAssetsControllerTest()
        {
            _fakeDbContext = new FakeDbContext();
            _fakeDbContext.Reset();
        }

        [TestMethod]
        public async Task RankedAssetsController_GetRankedAsset()
        {
            // Arrange
            RankedAssetsController controller = new RankedAssetsController(_fakeDbContext.Context);
            List<RankedAssetDTO> expectedResult = _fakeDbContext.ExpectedResultOf_RankedAssetsController_GetRankedAsset();

            // Act
            var request = (dynamic)await controller.GetRankedAsset(1);
            var result = request.Value;

            // Assert
            Assert.AreEqual(expectedResult.Count, result.Count);

            for (int i = 0; i < result.Count; i++)
            {
                Assert.AreEqual(expectedResult[i], result[i]);
            }
        }

        [TestMethod]
        public async Task RankedAssetsController_Post()
        {
            // Arrange
            RankedAssetsController controller = new RankedAssetsController(_fakeDbContext.Context);
            PostRankedAssetDTO postRankedAssetDTO = _fakeDbContext.Seed_RankedAssetsController_PostAsset();
            RankedAssetDTO expectedResult = _fakeDbContext.ExpectedResultOf_RankedAssetsController_Post();

            // Act
            var request = (dynamic)await controller.PostRankedAsset(postRankedAssetDTO);
            var result = request.Result.Value;

            // Assert
            Assert.AreEqual(3, _fakeDbContext.Context.Assets.Count());
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public async Task RankedAssetsController_Delete()
        {
            // Arrange
            RankedAssetsController controller = new RankedAssetsController(_fakeDbContext.Context);

            // Act
            await controller.DeleteRankedAsset(4);
            var result = _fakeDbContext.Context.RankedAssets.FirstOrDefault(x => x.Id == 4);

            // Assert
            Assert.AreEqual(null, result);
        }
    }
}
