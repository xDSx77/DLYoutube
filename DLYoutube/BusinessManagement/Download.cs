using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace DLYoutube.BusinessManagement
{
    class Download
    {
        private DataAccess.Download download { get; }
        private DataAccess.Storage storage { get; }


        public Download()
        {
            download = new DataAccess.Download();
            storage = new DataAccess.Storage();
        }

        public async Task<bool> DownloadVideo(string[] urlVideos)
        {
            bool error = false;
            foreach (string urlVideo in urlVideos)
            {
                try
                {
                    (Stream stream, string title) video = await download.DownloadVideo(urlVideo);
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
            bool error = false;
            try
            {
                IAsyncEnumerable<(Stream stream, string title)> channelVideos = download.DownloadChannel(channelId);
                await foreach ((Stream stream, string title) video in channelVideos)
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
