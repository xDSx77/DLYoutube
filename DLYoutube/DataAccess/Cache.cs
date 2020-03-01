using DLYoutube.Dbo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace DLYoutube.DataAccess
{
    public class Cache : ICache
    {
        private Dbo.Cache _cache;

        public Cache(string xmlfilename = "cache.xml")
        {
            if (File.Exists(xmlfilename))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Dbo.Cache));
                using (XmlReader reader = XmlReader.Create(xmlfilename))
                {
                    _cache = (Dbo.Cache)serializer.Deserialize(reader);
                }
            }
            else
                _cache = new Dbo.Cache();
        }

        public bool AddTitle(string channelId, string title)
        {
            try
            {
                var channel = from c in _cache.Channels where c.ChannelId == channelId select c;
                if (channel.Any())
                {
                    Channel channel2 = channel.First();
                    channel2.Titles.Add(title);
                    return true;
                }
                Channel newchannel = new Channel(channelId);
                newchannel.Titles.Add(title);
                _cache.Channels.Add(newchannel);
                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }

        public bool SaveCache(string filename = "cache.xml")
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Dbo.Cache));
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                using (XmlWriter writer = XmlWriter.Create(filename, settings))
                {
                    serializer.Serialize(writer, (Dbo.Cache)_cache);
                }
                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }

        public bool? VideoExists(string channelId, string title)
        {
            var channel = from c in _cache.Channels where c.ChannelId == channelId select c;
            if (channel == null)
                return null;
            var videoExists = from c in channel where c.Titles.Contains(title) select c.Titles.Contains(title);
            if (videoExists.Any())
                return true;
            return false;
        }
    }
}
