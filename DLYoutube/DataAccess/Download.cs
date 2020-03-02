using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Models.MediaStreams;

namespace DLYoutube.DataAccess
{
    public class Download
    {
        private YoutubeClient _client;
        private ICache _cache;

        public Download(ICache cache)
        {
            _client = new YoutubeClient();
            _cache = cache;
        }

        private async Task<(Stream stream, string title)> GetStreamAndVideoInfo(string idVideo)
        {
            YoutubeExplode.Models.Video video = await _client.GetVideoAsync(idVideo);
            MediaStreamInfoSet streamInfoSet = await _client.GetVideoMediaStreamInfosAsync(idVideo);
            MuxedStreamInfo streamInfo = streamInfoSet.Muxed.WithHighestVideoQuality();
            MediaStream stream = await _client.GetMediaStreamAsync(streamInfo);
            return (stream, video.Title);
        }

        public async Task<(Stream stream, string title)> DownloadVideo(string urlVideo)
        {
            string idVideo = YoutubeClient.ParseVideoId(urlVideo);
            return await GetStreamAndVideoInfo(idVideo);
        }

        public async IAsyncEnumerable<(Stream stream, string title)> DownloadChannel(string channelId, bool hasDiff)
        {
            IReadOnlyList<YoutubeExplode.Models.Video> channelVideos = await _client.GetChannelUploadsAsync(channelId);
            foreach (YoutubeExplode.Models.Video video in channelVideos)
            {
                (Stream stream, string title) = await GetStreamAndVideoInfo(video.Id);
                if (hasDiff)
                {
                    bool? exists = _cache.VideoExists(channelId, title);
                    if (exists.HasValue && exists.Value)
                        continue;
                }
                _cache.AddTitle(channelId, title);
                _cache.SaveCache();
                yield return (stream, title);
            }
        }

    }
}
