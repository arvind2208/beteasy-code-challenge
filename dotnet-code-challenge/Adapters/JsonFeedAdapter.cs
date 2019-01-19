using System;
using dotnet_code_challenge.Helpers;
using dotnet_code_challenge.Models;

namespace dotnet_code_challenge.Adapters
{
    public class JsonFeedAdapter : IFeedAdapter
    {
        private readonly IFileSystem _fileSystem;

        public JsonFeedAdapter(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;
        }

        public void Fill(string filePath, DataSet dataSet)
        {
            throw new NotImplementedException();
        }
    }
}
