using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaxiService.BusinessLayer;
using TaxiService.DataLayer;
using Xunit;
using TaxiService;

namespace TaxiService.BusinessLayerTest
{
    public class OrderServiceTest
    {
        private Task<List<Order>> GetListOrderAsync()
        {
            return Task.Run(() => new List<Order>
            {
                new Order {OrderDate = Convert.ToDateTime("13/08/2021 10:00"),
                                   OrderComplateDate = Convert.ToDateTime("13/08/2021 11:00"),
                                   OrderAddressSource = "Simi Prakhovykh, 54",
                                   OrderAddressDestination = "Kudryashova, 14-B",
                                   OrderStatus = ((int)OrderStatus.Done),
                                   Car = new Car
                                   {
                                       CarNumber = "Car1",
                                       CarModel = "Tesla",
                                       CarDriverFIO = "John Do"
                                   }},
                new Order
                           {
                               OrderDate = Convert.ToDateTime("13/08/2021 08:00"),
                               OrderComplateDate = Convert.ToDateTime("13/08/2021 09:00"),
                               OrderAddressSource = "Simi Prakhovykh, 54",
                               OrderAddressDestination = "Kudryashova, 14-B",
                               OrderStatus = ((int)OrderStatus.Done),
                               Car = new Car
                               {
                                   CarNumber = "Car2",
                                   CarModel = "Renault",
                                   CarDriverFIO = "Carl Jo"
                               }
                           },
            new Order
            {
                OrderDate = Convert.ToDateTime("13/08/2021 9:00"),
                OrderComplateDate = Convert.ToDateTime("13/08/2021 9:30"),
                OrderAddressSource = "Simi Prakhovykh, 54",
                OrderAddressDestination = "Kudryashova, 14-B",
                OrderStatus = ((int)OrderStatus.Done),
                Car = new Car
                {
                    CarNumber = "Car3",
                    CarModel = "Maclaren",
                    CarDriverFIO = "Lewis Ham"
                }
            },
            new Order
            {
                OrderDate = Convert.ToDateTime("13/08/2021 11:00"),
                OrderAddressSource = "Simi Prakhovykh, 54",
                OrderAddressDestination = "Kudryashova, 14-B",
                OrderStatus = ((int)OrderStatus.Waiting)
            },
            new Order
            {
                OrderDate = Convert.ToDateTime("13/08/2021 11:00"),
                OrderAddressSource = "Simi Prakhovykh, 54",
                OrderAddressDestination = "Kudryashova, 14-B",
                OrderStatus = ((int)OrderStatus.InProgress),
                Car = new Car
                {
                    CarNumber = "Car4",
                    CarModel = "Ferrary",
                    CarDriverFIO = "Fernando Alonso"
                }
            },
            new Order
            {
                OrderDate = Convert.ToDateTime("13/08/2021 12:00"),
                OrderAddressSource = "Simi Prakhovykh, 54",
                OrderAddressDestination = "Kudryashova, 14-B",
                OrderStatus = ((int)OrderStatus.InProgress),
                Car = new Car
                {
                    CarNumber = "Car5",
                    CarModel = "Volvo",
                    CarDriverFIO = "Seb Vettel"
                }
            },
            new Order
            {
                OrderDate = Convert.ToDateTime("13/08/2021 10:00"),
                OrderComplateDate = Convert.ToDateTime("13/08/2021 11:00"),
                OrderAddressSource = "Simi Prakhovykh, 54",
                OrderAddressDestination = "Kudryashova, 14-B",
                OrderStatus = ((int)OrderStatus.Done),
                Car = new Car
                {
                    CarNumber = "Car1",
                    CarModel = "Tesla",
                    CarDriverFIO = "John Do"
                }
            }
            });
        }
        private Task<List<Car>> GetListCarAsync()
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
        public async Task<List<Order>> GetTestOrders()
        {
            List<Order> orders = await GetListOrderAsync();
            return orders;
        }

        private List<Order> GetTestWaitngOrders()
        {
            var orders = new List<Order>
            {
            new Order
            {
                OrderDate = Convert.ToDateTime("13/08/2021 11:00"),
                OrderAddressSource = "Simi Prakhovykh, 54",
                OrderAddressDestination = "Kudryashova, 14-B",
                OrderStatus = ((int)OrderStatus.Waiting)
            }};
            return orders;
        }
       private async Task<List<Car>> GetTestCars()
        {
            List<Car> cars = await GetListCarAsync();
            return cars;
        }
        [Fact]
        public async void OrderServiceTestCountOrders()
        {
            var mockOrder = new Mock<IOrderRepository>();
            var mockCar = new Mock<ICarRepository>();
            mockOrder.Setup(p => p.GetOrderAsync()).Returns(GetTestOrders());
            mockCar.Setup(p => p.GetAllCarsAsync()).Returns(GetTestCars());
            var order = await new OrderService(mockOrder.Object, mockCar.Object).GetOrdersAsync();
            Assert.Equal(7, order.Count);
        }
    }
}
