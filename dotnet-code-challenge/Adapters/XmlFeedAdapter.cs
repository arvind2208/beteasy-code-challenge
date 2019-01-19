using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using dotnet_code_challenge.Adapters.XmlDtos;
using dotnet_code_challenge.Helpers;
using dotnet_code_challenge.Models;

namespace dotnet_code_challenge.Adapters
{
    public class XmlFeedAdapter : IFeedAdapter
    {
        private readonly IFileSystem _fileSystem;

        public XmlFeedAdapter(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;
        }

        public void Fill(string filePath, DataSet dataSet)
        {
            string content = _fileSystem.ReadAllText(filePath);

            XmlSerializer serializer = new XmlSerializer(typeof(Meeting));
            Meeting meeting;
            using (TextReader reader = new StringReader(content))
            {
                meeting = (Meeting)serializer.Deserialize(reader);
            }

            if (dataSet.Horses == null)
            {
                dataSet.Horses = new List<Models.Horse>();
            }

            foreach (var race in meeting.Races.Race)
            {
                var horsePrices = race.Prices.Price;
                race.Horses.Horse.ForEach(x =>
                {
                    double price = 0;
                    var horsePrice = horsePrices.Horses.Horse
                    .SingleOrDefault(hp => hp._Number == x.Number);

                    if (horsePrice != null)
                        price = Convert.ToDouble(horsePrice.Price);

                    dataSet.Horses.Add(new Models.Horse
                    {
                        Number = Convert.ToInt32(x.Number),
                        Name = x.Name,
                        Price = price
                    });
                }
                );
            }
        }
    }
}
