using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxiService.DataLayer;

namespace TaxiService
{
    public static class SampleData
    {
        public static void Initialize(TaxiContext context)
        {
            if (!context.Order.Any())
                       {
                           context.Order.AddRange(
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
                                       CarDriverFIO = "John Do",
                                       CarReady = true
                                   }
                               },
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
                                       CarDriverFIO = "Carl Jo",
                                       CarReady = true
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
                                       CarDriverFIO = "Lewis Ham",
                                       CarReady = true
                                   }
                               },
                               new Order
                               {
                                   OrderDate = Convert.ToDateTime("13/08/2021 11:00"),
                                   OrderAddressSource = "Simi Prakhovykh, 54",
                                   OrderAddressDestination = "Kudryashova, 14-B",
                                   OrderStatus = ((int)OrderStatus.Waiting)
                               } ,
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
                                       CarDriverFIO = "Fernando Alonso",
                                       CarReady = false
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
                                       CarDriverFIO = "Seb Vettel",
                                       CarReady = false
                                   }
                               }
                           );
                           context.Car.AddRange(
                               new Car
                               {
                                   CarNumber = "Car6",
                                   CarModel = "Kia",
                                   CarDriverFIO = "Ivanov Ivan",
                                   CarReady = true
                               },
                               new Car
                               {
                                   CarNumber = "Car7",
                                   CarModel = "Fiat",
                                   CarDriverFIO = "Petrov Kiril",
                                   CarReady = true
                               }
                           );
                           context.SaveChanges();
            }
        }
    }
}
