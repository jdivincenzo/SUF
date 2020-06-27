using Services.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ServicesTest.Fakes
{
    public class FakeFileUtils : IFileUtils
    {
        public void SaveFile(Stream stream, string fileName) { }
    }
}
