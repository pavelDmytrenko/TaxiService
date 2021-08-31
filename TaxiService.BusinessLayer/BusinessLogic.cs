using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxiService.DataLayer;

namespace TaxiService.BusinessLayer
{
    public class BusinessLogic
    {
        private readonly TaxiContext _context;
        private readonly DBOperation _dbOperation;
        public Car Car { get; set; }
        public Order Order { get; set; }
        public BusinessLogic(TaxiContext dbContext)
        {
            _context = dbContext;
            _dbOperation = new DBOperation(_context);
        }

        public async Task<Car> GetCar(int? id)
        {
            if (id == -1)
            {
                Car = new Car { CarNumber = "", CarModel = "", CarDriverFIO = "" };
            }
            Car = await _dbOperation.GetCarById(id);
            return Car;
        }
        /*         findStatus
        free cars -    1
        nofree cars -  2
        all cars    -  3
          */
        public List<Car> GetCar(int findStatus)
        {
            switch (findStatus)

            {
                case  1 :
                    return _dbOperation.GetFreeCar();
                    
                case 2:
                    return _dbOperation.GetNotFreeCar();
                    
                case 3:
                    return _dbOperation.GetCars();
            }
            return null;
        }

        public async Task<Order> GetOrder(int? id)
        {
            if (id == -1)
            {
                Order = new Order { OrderDate = default(DateTime), OrderAddressDestination = "", OrderAddressSource = "", OrderStatus = "" };
            }

            Order = await _dbOperation.GetOrderById(id);
            return Order;
        }
        /*         findStatus
                    waitnig orders  - 2
                    all orders    -  3
        */
        public List<Order> GetOrder(int findStatus)
        {
            switch (findStatus)

            {
                case 2:
                    return _dbOperation.GetWaitingOrder();

                case 3:
                    return _dbOperation.GetOrder();
            }
            return null;

        }

        public async Task AddCar(Car car)
        {
            var CarDb = await _dbOperation.GetCarById(car.CarID);
            if (CarDb == null)
            {
                await _dbOperation.AddCar(car);
            }
            else
            {
                CarDb.CarNumber = car.CarNumber;
                CarDb.CarModel = car.CarModel;
                CarDb.CarDriverFIO = car.CarDriverFIO;
                await _dbOperation.SaveChanges();
            }
        }

        public async Task AddOrder(Order order)
        {
            if (order.OrderId == 0)
            {
                order.OrderStatus = "waiting";
                await _dbOperation.AddOrder(order);
            }
            else if (order.OrderId > 0)
            {
                var OrderDb = await _dbOperation.GetOrderById(order.OrderId);
                OrderDb.OrderComplateDate = order.OrderComplateDate;
                OrderDb.OrderStatus = "done";
                await _dbOperation.SaveChanges();
            }
        }
        public async Task AddOrder(Order order, int carselectedID)
        {
            var car = await _dbOperation.GetCarById(carselectedID);
            var orderDb = await _dbOperation.GetOrderById(order.OrderId);
            orderDb.Car = car;
            orderDb.OrderStatus = "in progress";
            await _dbOperation.SaveChanges();
        }
        public async Task DelOrder (Order order)
        {
            var orderDel = await _dbOperation.GetOrderById(order.OrderId);
            if (orderDel != null)
                {
                  await _dbOperation.DelOrder(order);
                }
        }
    }
}
