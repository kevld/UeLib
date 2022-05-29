using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UeLib.Data.DTO;
using UeLib.Data.Models;

namespace UeLib.Test.Data.Models
{
    [TestClass]
    public class ProjectTest
    {
        [TestMethod]
        public void EqualsNull()
        {
            // Arrange
            Project p = new Project()
            {
                Id = 1,
                Name = "Name",
                Description = "Description",
                RankedAssets = new List<RankedAsset>()
            };
            Project p2 = null;

            Assert.AreEqual(false, p.Equals(p2));
        }
    }
}
