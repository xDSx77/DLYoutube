using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using DLYoutube.DataAccess;
using System.IO;
using System.Threading.Tasks;

namespace DLYoutubeUnitTest.DataAccess
{
    [TestClass]
    public class DAStorageTest
    {
        [TestMethod]
        public async Task SaveFileTest()
        {
            Storage storage = new Storage();
            bool ok = await storage.SaveFile(new MemoryStream(), "test");
            Assert.AreEqual(ok, true);
        }

        [TestMethod]
        public async Task SaveFileErrorTest() 
        {
            Storage storage = new Storage();
            bool ok = await storage.SaveFile(new MemoryStream(), "</?!>");
            Assert.AreEqual(ok, false);
        }
    }
}
