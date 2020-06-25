using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Services.Common
{
    public static class FileUtils
    {
        public static void SaveFile(Stream stream, String fileName)
        {
            string path = Path.Combine(@"c:\\SUF_imgs", fileName);
            using (FileStream outputFileStream = new FileStream(path, FileMode.Create))
            {
                stream.CopyTo(outputFileStream);
            }
        }
    }
}
