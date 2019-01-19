using dotnet_code_challenge.Models;

namespace dotnet_code_challenge.Adapters
{
    public interface IFeedAdapter
    {
        void Fill(string filePath, DataSet dataSet);
    }
}
