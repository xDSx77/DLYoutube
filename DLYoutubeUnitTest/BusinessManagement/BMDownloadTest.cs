using Microsoft.VisualStudio.TestTools.UnitTesting;
using DLYoutube.BusinessManagement;
using System.Threading.Tasks;

namespace DLYoutubeUnitTest.BusinessManagement
{
    [TestClass]
    public class BMDownloadTest
    {
        [TestMethod]
        public async Task DownloadVideoTest()
        {
            Download download = new Download();
            bool ok = await download.DownloadVideo(new string[] { "https://www.youtube.com/watch?v=wHpu_Fyc4_8", "https://www.youtube.com/watch?v=IB9iVl-geRM" });
            Assert.AreEqual(ok, true);
        }

        [TestMethod]
        public async Task DownloadVideoErrorTest()
        {
            Download download = new Download();
            bool ok = await download.DownloadVideo(new string[] { "errorUrl", "errorUrl2" });
            Assert.AreEqual(ok, false);
        }

        [TestMethod]
        public async Task DownloadChannelTest()
        {
            Download download = new Download();
            bool ok = await download.DownloadChannel("UCMGYe4FAUl1yX6y8yhb7a6A", false);
            Assert.AreEqual(ok, true);
        }

        [TestMethod]
        public async Task DownloadChannelHasDiffTest()
        {
            Download download = new Download();
            bool ok = await download.DownloadChannel("UCMGYe4FAUl1yX6y8yhb7a6A", true);
            Assert.AreEqual(ok, true);
        }

        [TestMethod]
        public async Task DownloadChannelErrorTest()
        {
            Download download = new Download();
            bool ok = await download.DownloadChannel("errorId", false);
            Assert.AreEqual(ok, false);
        }
    }
}
