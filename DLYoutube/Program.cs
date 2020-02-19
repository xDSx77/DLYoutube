using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using DLYoutube.BusinessManagement;

namespace DLYoutube
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Download download = new Download();
            await download.DownloadChannel("UCpnkp_D4FLPCiXOmDhoAeYA");
        }
    }
}
