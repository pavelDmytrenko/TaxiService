using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaxiService.BusinessLayer;
using TaxiService.DataLayer;
using TaxiService.DataLayerTest;
using Xunit;

namespace TaxiService.BusinessLayerTest
{
    public class CarServiceTest
    {
        private Task<List<Car>> GetListAsync()
        {
            return Task.Run(() => new List<Car>
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
            });
        }
        public async Task<List<Car>> GetTestCars()
        {
            List<Car> cars = await GetListAsync();
            return cars;
        }
        [Fact]
        public async void BusinessLogicTestCountCars()
        {
            var mock = new Mock<ICarRepository>();
            mock.Setup(p => p.GetAllCarsAsync()).Returns(GetTestCars());
            List<Car> car = await new CarService(mock.Object).GetAllCarsAsync();
            Assert.Equal(6, car.Count);
        }
    }
}
