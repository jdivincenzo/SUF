using System;
using System.Configuration;
using System.IO;

namespace Services.Common
{
    public class FileUtils : IFileUtils
    {
        public void SaveFile(Stream stream, String fileName)
        {
            string path = Path.Combine(ConfigurationManager.AppSettings["ImagePath"], Guid.NewGuid().ToString() + Path.GetExtension(fileName));
            using FileStream outputFileStream = new FileStream(path, FileMode.Create);
            stream.CopyTo(outputFileStream);
        }
    }
}
