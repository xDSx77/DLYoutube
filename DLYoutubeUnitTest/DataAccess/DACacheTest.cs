using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using DLYoutube.DataAccess;
using System.IO;

namespace DLYoutubeUnitTest.DataAccess
{
    [TestClass]
    public class DACacheTest
    {
        [TestMethod]
        public void CreateCacheTest()
        {
            Cache cache = new Cache();
        }

        [TestMethod]
        public void CreateCacheWIthFileTest()
        {
            Cache cache = new Cache("test.xml");
        }

        [TestMethod]
        public void CreateCacheWithNullTest()
        {
            Cache cache = new Cache(null);
        }

        [TestMethod]
        public void AddTitleTest()
        {
            Cache cache = new Cache();
            Assert.IsTrue(cache.AddTitle("id", "title"));
        }

        [TestMethod]
        public void SaveCacheTest()
        {
            Cache cache = new Cache();
            Assert.IsTrue(cache.SaveCache());
        }

        [TestMethod]
        public void SaveCacheWithFileTest()
        {
            Cache cache = new Cache();
            Assert.IsTrue(cache.SaveCache("test.xml"));
        }

        [TestMethod]
        public void SaveCacheWithNullTest()
        {
            Cache cache = new Cache();
            Assert.IsFalse(cache.SaveCache(null));
        }

        [TestMethod]
        public void VideoExistsTest()
        {
            Cache cache = new Cache();
            Assert.IsTrue(cache.VideoExists("id", "title").HasValue);
        }
    }
}
