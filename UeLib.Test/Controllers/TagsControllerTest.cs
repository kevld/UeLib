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
    public class TagsControllerTest
    {
        private readonly FakeDbContext _fakeDbContext;

        public TagsControllerTest()
        {
            _fakeDbContext = new FakeDbContext();
            _fakeDbContext.Reset();
        }

        [TestMethod]
        public async Task TagsController_Get()
        {
            // Arrange
            TagsController controller = new TagsController(_fakeDbContext.Context);
            List<TagDTO> expectedResult = _fakeDbContext.ExpectedResultOf_TagsController_GetAll();

            // Act
            IEnumerable<TagDTO> request = await controller.GetTags();
            List<TagDTO> result = request.ToList();

            // Assert
            Assert.AreEqual(expectedResult.Count, result.Count);

            for (int i = 0; i < result.Count; i++)
            {
                Assert.AreEqual(expectedResult[i], result[i]);
            }
        }

        [TestMethod]
        public async Task TagsController_Post()
        {
            // Arrange
            TagsController controller = new TagsController(_fakeDbContext.Context);
            string tagName = _fakeDbContext.Seed_TagsController_Post().Name;
            TagDTO expectedResult = _fakeDbContext.ExpectedResultOf_TagsController_PostTag();

            // Act 
            var request = (dynamic)await controller.PostTag(tagName); // Existing tag
            var result = request.Result.Value;

            // Assert
            Assert.AreEqual(3, _fakeDbContext.Context.Assets.Count());
            Assert.AreEqual(expectedResult, result);
        }
    }
}
