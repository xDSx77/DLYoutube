using System;
using System.Collections.Generic;
using System.Text;

namespace DLYoutube.Dbo
{
    public class Channel
    {
        public List<string> Titles { get; set; }
        public string ChannelId { get; set; }

        public Channel()
        {
            Titles = new List<string>();
        }

        public Channel(string channelId) : this()
        {
            ChannelId = channelId;
        }
    }
}