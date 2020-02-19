using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Models.MediaStreams;

namespace DLYoutube.DataAccess
{
    class Download
    {
        private YoutubeClient client { get; }

        public Download()
        {
            client = new YoutubeClient();
        }

        private async Task<(Stream stream, string title)> GetStreamAndVideoInfo(string idVideo)
        {
            YoutubeExplode.Models.Video video = await client.GetVideoAsync(idVideo);
            MediaStreamInfoSet streamInfoSet = await client.GetVideoMediaStreamInfosAsync(idVideo);
            MuxedStreamInfo streamInfo = streamInfoSet.Muxed.WithHighestVideoQuality();
            MediaStream stream = await client.GetMediaStreamAsync(streamInfo);
            return (stream, video.Title);
        }

        public async Task<(Stream stream, string title)> DownloadVideo(string urlVideo)
        {
            string idVideo = YoutubeClient.ParseVideoId(urlVideo);
            (Stream stream, string title) = await GetStreamAndVideoInfo(idVideo);
            return (stream, title);
        }

        public async IAsyncEnumerable<(Stream stream, string title)> DownloadChannel(string channelId)
        {
            IReadOnlyList<YoutubeExplode.Models.Video> channelVideos = await client.GetChannelUploadsAsync(channelId);
            foreach (YoutubeExplode.Models.Video video in channelVideos)
            {
                (Stream stream, string title) = await GetStreamAndVideoInfo(video.Id);
                yield return (stream, title);
            }
        }

    }
}
