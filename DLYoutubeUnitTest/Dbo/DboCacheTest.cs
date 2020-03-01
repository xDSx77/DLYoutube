using DLYoutube.Dbo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace DLYoutubeUnitTest.Dbo
{
    [TestClass]
    public class DboCacheTest
    {
        [TestMethod]
        public void CreateCacheTest()
        {
            Cache cache = new Cache();
            Assert.IsNotNull(cache.Channels);
            Assert.AreEqual(cache.Channels.Count, 0);
        }

        [TestMethod]
        public void AddChannelTest()
        {
            Cache cache = new Cache();
            Channel channel = new Channel();
            List<Channel> channels = new List<Channel>() { channel };
            cache.Channels = channels;
            Assert.AreEqual(cache.Channels, channels);
            Assert.AreSame(cache.Channels, channels);
        }

        [TestMethod]
        public void AddChannelsTest()
        {
            Cache cache = new Cache();
            Channel channel = new Channel();
            List<Channel> channels = new List<Channel>() { channel, channel };
            cache.Channels = channels;
            Assert.AreEqual(cache.Channels, channels);
            Assert.AreSame(cache.Channels, channels);

        }
    }
}
