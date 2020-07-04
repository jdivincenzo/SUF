using System.IO;

namespace Services.Common
{
    public interface IFileUtils
    {
        string SaveFile(Stream stream, string fileName);
    }
}