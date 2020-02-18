using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using DLYoutube.BusinessManagement;

namespace DLYoutube
{
    class Program
    {
        static async Task<int> Main(string[] args)
        {
            Download download = new Download();
            bool isOk = await download.DownloadChannel("UCpnkp_D4FLPCiXOmDhoAeYA");
            if (isOk == true)
                return 0;
            else
                return -1;
        }
    }
}
