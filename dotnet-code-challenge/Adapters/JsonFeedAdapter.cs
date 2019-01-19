using System;
using System.Collections.Generic;
using System.Linq;
using dotnet_code_challenge.Adapters.JsonDtos;
using dotnet_code_challenge.Helpers;
using dotnet_code_challenge.Models;
using Newtonsoft.Json;

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
            string content = _fileSystem.ReadAllText(filePath);

            var root = JsonConvert.DeserializeObject<Root>(content);

            var selections = root.RawData.Markets.SelectMany(x => x.Selections);

            if (dataSet.Horses == null)
            {
                dataSet.Horses = new List<Models.Horse>();
            }

            selections.ToList().ForEach(x =>
            {
                dataSet.Horses.Add(new Horse
                {
                    Name = x.Tags.Name,
                    Price = Convert.ToDouble(x.Price)
                });
            });
        }
    }
}
