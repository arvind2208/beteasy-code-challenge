using dotnet_code_challenge.Models;

namespace dotnet_code_challenge.Adapters
{
    public interface IFeedAdapter
    {
        string FilePath { get; set; }
        void Fill(DataSet dataSet);
    }
}
