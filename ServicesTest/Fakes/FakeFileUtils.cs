using Services.Common;
using System.IO;

namespace ServicesTest.Fakes
{
    public class FakeFileUtils : IFileUtils
    {
        public string SaveFile(Stream stream, string fileName) { return "GuidFilename"; }
    }
}
