using Services.Common;
using System.IO;

namespace ServicesTest.Fakes
{
    public class FakeFileUtils : IFileUtils
    {
        public void SaveFile(Stream stream, string fileName) { }
    }
}
