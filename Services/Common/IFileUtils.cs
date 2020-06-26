using System.IO;

namespace Services.Common
{
    public interface IFileUtils
    {
        void SaveFile(Stream stream, string fileName);
    }
}