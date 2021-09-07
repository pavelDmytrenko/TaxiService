
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using TaxiService.DataLayer;
using Xunit;

namespace TaxiService.DataLayerTest
{
    public class OrderRepositoryTest
    {
        public enum OrderStatus
        {
            InProgress = 1,
            Waitnig = 2,
            Done = 3
        }
        public List<Order> GetTestOrders()
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
                OrderStatus = ((int)OrderStatus.Waitnig)
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
        public OrderRepository GetDBContext()
        {
            var users = MockDbSet(GetTestOrders());
            var dbContext = new Mock<IDbContext>();
            dbContext.Setup(m => m.Order).Returns(users);
            return new OrderRepository(dbContext.Object);
        }
        public static DbSet<T> MockDbSet<T>(List<T> sourceList) where T : class
        {
            var queryable = sourceList.AsQueryable();
            var dbSet = new Mock<DbSet<T>>();
            dbSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryable.Provider);
            dbSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
            dbSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            dbSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());
            dbSet.Setup(d => d.Add(It.IsAny<T>())).Callback<T>((s) => sourceList.Add(s));
            return dbSet.Object;
        }

        [Fact]
        public void OrderRepositoryTestCountOrders()
        {
            List<Order> order = GetDBContext().GetOrder();
            Assert.Equal(7, order.Count);
        }

        [Fact]
        public void DBOperationTestGetWaitingOrder()
        {
            List<Order> order = GetDBContext().GetWaitingOrder();
            Assert.Equal(1, order.Count);

        }
    }
}
