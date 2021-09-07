using Moq;
using System;
using System.Collections.Generic;
using TaxiService.BusinessLayer;
using TaxiService.DataLayer;
using Xunit;
using static TaxiService.BusinessLayer.OrderService;

namespace TaxiService.BusinessLayerTest
{
    public class OrderServiceTest
    {
        public enum OrderStatus
        {
            InProgress = 1,
            Waiting = 2,
            Done = 3
        };
        private List<Order> GetTestOrders()
        {
        var orders = new List<Order>
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
            };
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
        public void OrderServiceTestCountOrders()
        {
            var mockOrder = new Mock<IOrderRepository>();
            var mockCar = new Mock<ICarRepository>();
            mockOrder.Setup(p => p.GetOrder()).Returns(GetTestOrders());
            mockCar.Setup(p => p.GetCars()).Returns(GetTestCars());
            Assert.Equal(7, new OrderService(mockOrder.Object, mockCar.Object).GetOrders().Count);
        }
        [Fact]
        public void OrderServiceTestCountWaitingOrders()
        {
            var mockOrder = new Mock<IOrderRepository>();
            var mockCar = new Mock<ICarRepository>();
            mockOrder.Setup(p => p.GetWaitingOrder()).Returns(GetTestWaitngOrders());
            mockCar.Setup(p => p.GetCars()).Returns(GetTestCars());
            Assert.Equal(1, new OrderService(mockOrder.Object, mockCar.Object).GetWaitingOrders().Count);
        }
    }
}
