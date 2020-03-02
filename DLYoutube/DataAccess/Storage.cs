using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using YoutubeExplode;

namespace DLYoutube.DataAccess
{
    public class Storage
    {
        public async Task<bool> SaveFile(Stream stream, string title)
        {
            try
            {
                FileStream fileStream = File.Create(Path.Combine(Directory.GetCurrentDirectory(), title + ".mp4"));
                await stream.CopyToAsync(fileStream);   
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }
    }
}
