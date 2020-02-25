using System;
using System.Collections.Generic;
using System.Text;

namespace DLYoutube.DataAccess
{
    public interface ICache
    {
        bool AddTitle(string channelId, string title);
        bool SaveCache(string filename = "cache.xml");
        bool? VideoExists(string channelId, string title);
    }
}
