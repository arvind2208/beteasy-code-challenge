using dotnet_code_challenge.Adapters;
using dotnet_code_challenge.Helpers;
using dotnet_code_challenge.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace dotnet_code_challenge.Test
{
    public class JsonFeedAdapterSpec
    {
        //TODO: Test more scenarios. Limited to two due to lack of time

        private readonly string _testData;

        public JsonFeedAdapterSpec()
        {
            _testData = File.ReadAllText("../../../TestData/Json_ValidResponse.json");
        }

        [Fact]
        public void FillDataSet_WhenProvidedValidJson_ReturnsListOfHorsesWithPrices()
        {
            var mockFileSystem = new Mock<IFileSystem>();

            mockFileSystem.Setup(x => x.ReadAllText(It.IsAny<string>()))
            .Returns(_testData);

            var jsonFeedAdapter = new JsonFeedAdapter(mockFileSystem.Object);

            var dataSet = new DataSet();

            jsonFeedAdapter.Fill(null, dataSet);

            Assert.Equal(2, dataSet.Horses.Count);

            Assert.Equal("Toolatetodelegate", dataSet.Horses[0].Name);
            Assert.Equal(10, dataSet.Horses[0].Price);

            Assert.Equal("Fikhaar", dataSet.Horses[1].Name);
            Assert.Equal(4.4, dataSet.Horses[1].Price);
        }

        [Fact]
        public void FillDataSet_WhenNoPriceProvided_ReturnsListOfHorsesWithPriceSetToZero()
        {
            var mockFileSystem = new Mock<IFileSystem>();

            string testData = File.ReadAllText("../../../TestData/Json_NoPrice.json");
            mockFileSystem.Setup(x => x.ReadAllText(It.IsAny<string>()))
            .Returns(testData);

            var jsonFeedAdapter = new JsonFeedAdapter(mockFileSystem.Object);

            var dataSet = new DataSet();

            jsonFeedAdapter.Fill(null, dataSet);

            Assert.Equal(2, dataSet.Horses.Count);

            Assert.Equal("Toolatetodelegate", dataSet.Horses[0].Name);
            Assert.Equal(10, dataSet.Horses[0].Price);

            Assert.Equal("Fikhaar", dataSet.Horses[1].Name);
            Assert.Equal(0, dataSet.Horses[1].Price);
        }

    }
}
