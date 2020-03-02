using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using DLYoutube.DataAccess;
using System.IO;
using System.Threading.Tasks;

namespace DLYoutubeUnitTest.DataAccess
{
    [TestClass]
    public class DADownloadTest
    {
        [TestMethod]
        public void DownloadTest()
        {
            Download download = new Download(new Cache());
        }

        [TestMethod]
        public async Task DownloadVideoTest() 
        {
            Download download = new Download(new Cache());
            await download.DownloadVideo("https://www.youtube.com/watch?v=zlFRXkeF8tU");
        }

        [TestMethod]
        public async Task DownloadChannelTest()
        {
            Download download = new Download(new Cache());
            download.DownloadChannel("UCPZUQqtVDmcjm4NY5FkzqLA", false);
        }

        [TestMethod]
        public async Task DownloadChannelHasDiffTest()
        {
            Download download = new Download(new Cache());
            download.DownloadChannel("UCPZUQqtVDmcjm4NY5FkzqLA", true);
        }
    }
}
