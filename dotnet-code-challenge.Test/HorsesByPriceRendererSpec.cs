using dotnet_code_challenge.Helpers;
using dotnet_code_challenge.Models;
using dotnet_code_challenge.Renderers;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace dotnet_code_challenge.Test
{
    public class HorsesByPriceRendererSpec
    {
        [Fact]
        public void Render_WhenInvalidHorseList_ThrowsException()
        {
            var mockWriter = new Mock<IWriter>();

            mockWriter.Setup(x => x.WriteLine(It.IsAny<string>()));

            var renderer = new HorsesByPriceRenderer(mockWriter.Object);

            var ex = Assert.Throws<ApplicationException>(()=> renderer.Render(null));

            Assert.Equal("Horses array provided to render is invalid", ex.Message);

        }

        [Fact]
        public void Render_WhenEmptyHorseList_DoesNotFail()
        {
            var mockWriter = new Mock<IWriter>();

            mockWriter.Setup(x => x.WriteLine(It.IsAny<string>()));

            var renderer = new HorsesByPriceRenderer(mockWriter.Object);

            renderer.Render(new List<Horse>());

        }
    }
}
