using Moq;
using System;
using System.Collections.Generic;
using TaxiService.BusinessLayer;
using TaxiService.DataLayer;
using TaxiService.DataLayerTest;
using Xunit;

namespace TaxiService.BusinessLayerTest
{
    public class CarServiceTest
    {
        private List<Car> GetTestCars()
        {
            var cars = new List<Car>
            {
                new Car
                                   {
                                       CarNumber = "Car1",
                                       CarModel = "Tesla",
                                       CarDriverFIO = "John Do"
                                   },
                new Car
                               {
                                   CarNumber = "Car2",
                                   CarModel = "Renault",
                                   CarDriverFIO = "Carl Jo"
                               },
                new Car
                    {
                        CarNumber = "Car3",
                        CarModel = "Maclaren",
                        CarDriverFIO = "Lewis Ham"
                    },
                new Car
                    {
                        CarNumber = "Car4",
                        CarModel = "Ferrary",
                        CarDriverFIO = "Fernando Alonso"
                    },
            new Car
                {
                    CarNumber = "Car5",
                    CarModel = "Volvo",
                    CarDriverFIO = "Seb Vettel"
                },
            new Car
                {
                    CarNumber = "Car1",
                    CarModel = "Tesla",
                    CarDriverFIO = "John Do"
                }
            };
            return cars;
        }
        [Fact]
        public void BusinessLogicTestCountCars()
        {
            var mock = new Mock<ICarRepository>();
            mock.Setup(p => p.GetCars()).Returns(GetTestCars());
            Assert.Equal(6, new CarService(mock.Object).GetAllCars().Count);
        }
        [Fact]
        public void BusinessLogicTestCountFreeCars()
        {
            var mock = new Mock<ICarRepository>();
            mock.Setup(p => p.GetFreeCars()).Returns(GetTestCars());
            Assert.Equal(6, new CarService(mock.Object).GetFreeCars().Count);
        }
        [Fact]
        public void BusinessLogicTestCountNotFreeCars()
        {
            var mock = new Mock<ICarRepository>();
            mock.Setup(p => p.GetNotFreeCars()).Returns(GetTestCars());
            Assert.Equal(6, new CarService(mock.Object).GetNotFreeCars().Count);
        }
    }
}
