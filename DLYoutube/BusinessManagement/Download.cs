using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace DLYoutube.BusinessManagement
{
    public class Download
    {
        private DataAccess.Download _download;
        private DataAccess.Storage _storage;


        public Download()
        {
            _download = new DataAccess.Download(new DataAccess.Cache());
            _storage = new DataAccess.Storage();
        }

        public async Task<bool> DownloadVideo(string[] urlVideos)
        {
            bool error = false;
            foreach (string urlVideo in urlVideos)
            {
                try
                {
                    (Stream stream, string title) video = await _download.DownloadVideo(urlVideo);
                    if (!await _storage.SaveFile(video.stream, video.title))
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

        public async Task<bool> DownloadChannel(string channelId, bool hasDiff)
        {
            bool error = false;
            try
            {
                IAsyncEnumerable<(Stream stream, string title)> channelVideos = _download.DownloadChannel(channelId, hasDiff);
                await foreach ((Stream stream, string title) video in channelVideos)
                {
                    if (!await _storage.SaveFile(video.stream, video.title))
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
