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
        public async Task<(Stream stream, string title)> DownloadVideo(string urlVideo)
        {
            var client = new YoutubeClient();
            
            string idVideo = YoutubeClient.ParseVideoId(urlVideo);
            var video = await client.GetVideoAsync(idVideo);
            var streamInfoSet = await client.GetVideoMediaStreamInfosAsync(idVideo);
            var streamInfo = streamInfoSet.Muxed.WithHighestVideoQuality();
            var stream = await client.GetMediaStreamAsync(streamInfo);
            
            return (stream, video.Title);
        }

        public async IAsyncEnumerable<(Stream stream, string title)> DownloadChannel(string channelId)
        {
            var client = new YoutubeClient();

            var channelVideos = await client.GetChannelUploadsAsync(channelId);
            foreach (var videos in channelVideos)
            {
                var video = await client.GetVideoAsync(videos.Id);
                var streamInfoSet = await client.GetVideoMediaStreamInfosAsync(videos.Id);
                var streamInfo = streamInfoSet.Muxed.WithHighestVideoQuality();
                var stream = await client.GetMediaStreamAsync(streamInfo);

                yield return (stream, video.Title);
            }
        }

    }
}
