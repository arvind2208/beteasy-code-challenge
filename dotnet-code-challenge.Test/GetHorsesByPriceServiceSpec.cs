using dotnet_code_challenge.Models;
using dotnet_code_challenge.Repositories;
using dotnet_code_challenge.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace dotnet_code_challenge.Test
{
    public class GetHorsesByPriceServiceSpec
    {
        [Fact]
        public void GetHorsesByPriceService_WhenRepositoryReturnsHorsesAscOrder_SortHorsesByPrice()
        {
            var mockRepository = new Mock<IRepository<Horse>>();

            mockRepository.Setup(x => x.GetAll())
            .Returns( new List<Horse>
            {
                new Horse
                {
                    Name = "Toolatetodelegate",
                    Number = 1,
                    Price = 4.4
                },
                 new Horse
                {
                    Name = "Fikhaar",
                    Number = 2,
                    Price = 10
                }
            });

            var service = new GetHorsesByPriceService(mockRepository.Object);

            var horses = service.Invoke().ToList();

            Assert.Equal(2, horses.Count);
            Assert.Equal("Toolatetodelegate", horses[0].Name);
            Assert.Equal(4.4, horses[0].Price);
            Assert.Equal("Fikhaar", horses[1].Name);
            Assert.Equal(10, horses[1].Price);
        }

        [Fact]
        public void GetHorsesByPriceService_WhenRepositoryReturnsHorsesDescOrder_SortHorsesByPrice()
        {
            var mockRepository = new Mock<IRepository<Horse>>();

            mockRepository.Setup(x => x.GetAll())
            .Returns(new List<Horse>
            {
                new Horse
                {
                    Name = "Toolatetodelegate",
                    Number = 1,
                    Price = 10
                },
                 new Horse
                {
                    Name = "Fikhaar",
                    Number = 2,
                    Price = 4.4
                }
            });

            var service = new GetHorsesByPriceService(mockRepository.Object);

            var horses = service.Invoke().ToList();

            Assert.Equal(2, horses.Count);
            Assert.Equal("Fikhaar", horses[0].Name);
            Assert.Equal(4.4, horses[0].Price);

            Assert.Equal("Toolatetodelegate", horses[1].Name);
            Assert.Equal(10, horses[1].Price);
        }
    }
}
