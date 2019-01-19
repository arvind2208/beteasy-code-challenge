using dotnet_code_challenge.Adapters;
using System.IO;

namespace dotnet_code_challenge.AdapterProviderFactory
{
    public class FeedAdapterProviderFactory
    {
        public IFeedAdapter GetFeedAdapter(string fileName)
        {
            var extension = Path.GetExtension(fileName);

            IFeedAdapter feedProvider = null;
            switch (extension)
            {
                case ".xml":
                    feedProvider = new XmlFeedAdapter();
                    break;
                case ".json":
                    feedProvider = new JsonFeedAdapter();
                    break;
            }

            return feedProvider;
        }
    }
}
