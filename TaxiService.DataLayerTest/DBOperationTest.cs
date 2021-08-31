using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using TaxiService.DataLayer;
using Xunit;

namespace TaxiService.DataLayerTest
{
    public class DBOperationTest
    {

        public DbContextOptions<TaxiContext> GetDBContext()
        {
        var options = new DbContextOptionsBuilder<TaxiContext>()
           .UseInMemoryDatabase(databaseName: "MockTaxidb")
           .Options;

            // Insert seed data into the database using one instance of the context
            using (var context = new TaxiContext(options))
            {

                context.Order.Add(new Order
                    {
                        OrderDate = Convert.ToDateTime("13/08/2021 10:00"),
                        OrderComplateDate = Convert.ToDateTime("13/08/2021 11:00"),
                        OrderAddressSource = "Simi Prakhovykh, 54",
                        OrderAddressDestination = "Kudryashova, 14-B",
                        OrderStatus = "done",
                        Car = new Car
                        {
                            CarNumber = "Car1",
                            CarModel = "Tesla",
                            CarDriverFIO = "John Do"
                        }
                    });
                context.Order.Add(new Order
                {
                    OrderDate = Convert.ToDateTime("13/08/2021 08:00"),
                    OrderComplateDate = Convert.ToDateTime("13/08/2021 09:00"),
                    OrderAddressSource = "Simi Prakhovykh, 54",
                    OrderAddressDestination = "Kudryashova, 14-B",
                    OrderStatus = "done",
                    Car = new Car
                    {
                        CarNumber = "Car2",
                        CarModel = "Renault",
                        CarDriverFIO = "Carl Jo"
                    }
                });
                context.Order.Add(new Order
                {
                    OrderDate = Convert.ToDateTime("13/08/2021 9:00"),
                    OrderComplateDate = Convert.ToDateTime("13/08/2021 9:30"),
                    OrderAddressSource = "Simi Prakhovykh, 54",
                    OrderAddressDestination = "Kudryashova, 14-B",
                    OrderStatus = "done",
                    Car = new Car
                    {
                        CarNumber = "Car3",
                        CarModel = "Maclaren",
                        CarDriverFIO = "Lewis Ham"
                    }
                });
                context.Order.Add(new Order
                {
                    OrderDate = Convert.ToDateTime("13/08/2021 11:00"),
                    OrderAddressSource = "Simi Prakhovykh, 54",
                    OrderAddressDestination = "Kudryashova, 14-B",
                    OrderStatus = "waiting"
                });
                context.Order.Add(new Order
                {
                    OrderDate = Convert.ToDateTime("13/08/2021 11:00"),
                    OrderAddressSource = "Simi Prakhovykh, 54",
                    OrderAddressDestination = "Kudryashova, 14-B",
                    OrderStatus = "in progress",
                    Car = new Car
                    {
                        CarNumber = "Car4",
                        CarModel = "Ferrary",
                        CarDriverFIO = "Fernando Alonso"
                    }
                });
                context.Order.Add(new Order
                    {
                        OrderDate = Convert.ToDateTime("13/08/2021 12:00"),
                        OrderAddressSource = "Simi Prakhovykh, 54",
                        OrderAddressDestination = "Kudryashova, 14-B",
                        OrderStatus = "in progress",
                        Car = new Car
                        {
                            CarNumber = "Car5",
                            CarModel = "Volvo",
                            CarDriverFIO = "Seb Vettel"
                        }
                    });
                context.Order.Add(new Order
                {
                    OrderDate = Convert.ToDateTime("13/08/2021 10:00"),
                    OrderComplateDate = Convert.ToDateTime("13/08/2021 11:00"),
                    OrderAddressSource = "Simi Prakhovykh, 54",
                    OrderAddressDestination = "Kudryashova, 14-B",
                    OrderStatus = "done",
                    Car = new Car
                    {
                        CarNumber = "Car1",
                        CarModel = "Tesla",
                        CarDriverFIO = "John Do"
                    }
                });
                context.SaveChanges();
            }
            return options;
        }
        [Fact]
        public void DBOperationTestCountOrders()
        {
            // Use a clean instance of the context to run the test
            using (var context = new TaxiContext(GetDBContext()))
            {
                DBOperation dBOperation = new DBOperation(context);
                List<Order> order = dBOperation.GetOrder();
    
            Assert.Equal(7, order.Count);
            }
        }

        [Fact]
        public void DBOperationTestCountFreeCars()
        {
            // Use a clean instance of the context to run the test
            using (var context = new TaxiContext(GetDBContext()))
            {
                DBOperation dBOperation = new DBOperation(context);
                List<Car> car = dBOperation.GetFreeCar();

                Assert.Empty(car);
            }
        }
        [Fact]
        public void DBOperationTestCountNotFreeCars()
        {
            // Use a clean instance of the context to run the test
            using (var context = new TaxiContext(GetDBContext()))
            {
                DBOperation dBOperation = new DBOperation(context);
                List<Car> car = dBOperation.GetNotFreeCar();

                Assert.Equal(18, car.Count);
            }
        }
    }
}
