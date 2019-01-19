using System;
using System.Collections.Generic;
using System.Text;
using dotnet_code_challenge.Models;

namespace dotnet_code_challenge.Adapters
{
    public class XmlFeedAdapter : IFeedAdapter
    {
        public string FilePath { get; set; }

        public void Fill(DataSet dataSet)
        {
            throw new NotImplementedException();
        }
    }
}
