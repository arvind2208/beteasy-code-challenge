using dotnet_code_challenge.Adapters;
using dotnet_code_challenge.Helpers;
using System.IO;

namespace dotnet_code_challenge.AdapterProviderFactory
{
    public class FeedAdapterProviderFactory
    {
        private readonly IFileSystem _fileSystem;

        public FeedAdapterProviderFactory(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;
        }

        public IFeedAdapter GetFeedAdapter(string fileName)
        {
            var extension = Path.GetExtension(fileName);

            IFeedAdapter feedProvider = null;
            switch (extension)
            {
                case ".xml":
                    feedProvider = new XmlFeedAdapter(_fileSystem);
                    break;
                case ".json":
                    feedProvider = new JsonFeedAdapter(_fileSystem);
                    break;
            }

            return feedProvider;
        }
    }
}
