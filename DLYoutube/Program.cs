using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.CommandLine;
using DLYoutube.BusinessManagement;

namespace DLYoutube
{
    class Program
    {
        /// <summary>
        /// Permet de telecharger des videos de youtube
        /// </summary>
        /// <param name="args">permet de mettre plusieurs urls de videos à télécharger</param>
        /// <param name="channel">url pour télécharger un channel complet</param>
        /// <returns></returns>
        private static async Task<int> Main(string[] args, string channel)
        {
            Download download = new Download();
            if (args != null)
                if (!await download.DownloadVideo(args))
                    return -1;
            if (channel != null)
                if (!await download.DownloadChannel(channel))
                    return -1;
            return 0;
        }
    }
}
