using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Services.Common
{
    public class FileUtils : IFileUtils
    {
        public void SaveFile(Stream stream, String fileName)
        {
            string path = Path.Combine(ConfigurationManager.AppSettings["ImagePath"], fileName);
            using (FileStream outputFileStream = new FileStream(path, FileMode.Create))
            {
                stream.CopyTo(outputFileStream);
            }
        }
    }
}
