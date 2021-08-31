using System;
using System.Collections.Generic;
using TaxiService.BusinessLayer;
using TaxiService.DataLayer;
using TaxiService.DataLayerTest;
using Xunit;

namespace TaxiService.BusinessLayerTest
{
    public class BusinessLogicTest
    {
        [Fact]
        public void BusinessLogicTestCountOrders()
        {
            DBOperationTest dBOperationTest = new DBOperationTest();
            using (var context = new TaxiContext(dBOperationTest.GetDBContext()))
            {
                BusinessLogic _busLogic = new BusinessLogic(context);
                List<Order> order = _busLogic.GetOrder(3);

                Assert.Equal(7, order.Count);
            }

        }
        [Fact]
        public void BusinessLogicTestCountCars()
        {
            DBOperationTest dBOperationTest = new DBOperationTest();
            using (var context = new TaxiContext(dBOperationTest.GetDBContext()))
            {
                BusinessLogic _busLogic = new BusinessLogic(context);
                List<Car> car = _busLogic.GetCar(3);

                Assert.Equal(12, car.Count);
            }
        }
    }
}
