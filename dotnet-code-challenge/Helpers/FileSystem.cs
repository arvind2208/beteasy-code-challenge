using System.IO;

namespace dotnet_code_challenge.Helpers
{
    public class FileSystem : IFileSystem
    {
        public string ReadAllText(string path)
        {
            return File.ReadAllText(path);
        }
    }
}
