using System;
using System.Collections.Generic;
using System.Text;

namespace DLYoutube.Dbo
{
    public class Cache
    {
        public List<Channel> Channels { get; set; }

        public Cache()
        {
            Channels = new List<Channel>();
        }
    }
}
