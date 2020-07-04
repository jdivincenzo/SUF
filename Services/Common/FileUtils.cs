using System;
using System.Configuration;
using System.IO;

namespace Services.Common
{
    public class FileUtils : IFileUtils
    {
        public string SaveFile(Stream stream, String fileName)
        {
            fileName = Guid.NewGuid().ToString() + Path.GetExtension(fileName);
            using FileStream outputFileStream = new FileStream(Path.Combine(ConfigurationManager.AppSettings["ImagePath"], fileName), FileMode.Create);
            stream.CopyTo(outputFileStream);
            return fileName;
        }
    }
}
