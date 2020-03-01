using DLYoutube.Dbo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace DLYoutubeUnitTest.Dbo
{
    [TestClass]
    public class DboChannelTest
    {
        [TestMethod]
        public void CreateChannelTest()
        {
            Channel channel = new Channel();
            Assert.IsNotNull(channel.Titles);
            Assert.AreEqual(channel.ChannelId, null);
        }

        [TestMethod]
        public void CreateChannelIdTest()
        {
            Channel channel2 = new Channel("id");
            Assert.IsNotNull(channel2.Titles);
            Assert.AreEqual(channel2.ChannelId, "id");
        }

        [TestMethod]
        public void CreateChannelNullTest()
        {
            Channel channel3 = new Channel(null);
            Assert.IsNotNull(channel3.Titles);
            Assert.AreEqual(channel3.ChannelId, null);
        }

        [TestMethod]
        public void AddTitleTest()
        {
            Channel channel = new Channel();
            List<string> titles = new List<string>() { "test" };
            channel.Titles = titles;
            Assert.AreEqual(channel.Titles, titles);
            Assert.AreSame(channel.Titles, titles);
        }

        [TestMethod]
        public void AddTitlesTest()
        {
            Channel channel = new Channel();
            List<string> titles = new List<string>() { "test", "test2" };
            channel.Titles = titles;
            Assert.AreEqual(channel.Titles, titles);
            Assert.AreSame(channel.Titles, titles);
        }
    }
}
