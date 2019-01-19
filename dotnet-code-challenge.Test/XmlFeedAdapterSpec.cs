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
    public class XmlFeedAdapterSpec
    {
        //TODO: Test more scenarios. Limited to two due to lack of time

        private readonly string _testData;

        public XmlFeedAdapterSpec()
        {
            _testData = File.ReadAllText("../../../TestData/Xml_ValidResponse.xml");
        }

        [Fact]
        public void FillDataSet_WhenProvidedValidXml_ReturnsListOfHorsesWithPrices()
        {
            var mockFileSystem = new Mock<IFileSystem>();

            mockFileSystem.Setup(x => x.ReadAllText(It.IsAny<string>()))
            .Returns(_testData);

            var xmlFeedAdapter = new XmlFeedAdapter(mockFileSystem.Object);

            var dataSet = new DataSet();

            xmlFeedAdapter.Fill(null, dataSet);

            Assert.Equal(2, dataSet.Horses.Count);

            Assert.Equal("Advancing", dataSet.Horses[0].Name);
            Assert.Equal(4.2, dataSet.Horses[0].Price);

            Assert.Equal("Coronel", dataSet.Horses[1].Name);
            Assert.Equal(12, dataSet.Horses[1].Price);
        }

        [Fact]
        public void FillDataSet_WhenNoValidPrice_ReturnsListOfHorsesWithPriceSetToZero()
        {
            var mockFileSystem = new Mock<IFileSystem>();

            string testData = File.ReadAllText("../../../TestData/Xml_NoPrice.xml");
            mockFileSystem.Setup(x => x.ReadAllText(It.IsAny<string>()))
            .Returns(testData);

            var xmlFeedAdapter = new XmlFeedAdapter(mockFileSystem.Object);

            var dataSet = new DataSet();

            xmlFeedAdapter.Fill(null, dataSet);

            Assert.Equal(2, dataSet.Horses.Count);

            Assert.Equal("Advancing", dataSet.Horses[0].Name);
            Assert.Equal(4.2, dataSet.Horses[0].Price);

            Assert.Equal("Coronel", dataSet.Horses[1].Name);
            Assert.Equal(0, dataSet.Horses[1].Price);
        }
    }
}
