using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace DLYoutube.BusinessManagement
{
    class Download
    {
        public async Task<bool> DownloadVideo(string[] urlVideos)
        {
            DataAccess.Download download = new DataAccess.Download();
            DataAccess.Storage storage = new DataAccess.Storage();
            bool error = false;
            foreach (string urlVideo in urlVideos)
            {
                try
                {
                    var video = await download.DownloadVideo(urlVideo);
                    if (!await storage.SaveFile(video.stream, video.title))
                        error = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    error = true;
                }
            }
            return !error;
        }

        public async Task<bool> DownloadChannel(string channelId)
        {
            DataAccess.Download download = new DataAccess.Download();
            DataAccess.Storage storage = new DataAccess.Storage();
            bool error = false;
            try
            {
                var channelVideos = download.DownloadChannel(channelId);
                await foreach (var video in channelVideos)
                {
                    if (!await storage.SaveFile(video.stream, video.title))
                        error = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                error = true;
            }
            return !error;
        }
    }
}
