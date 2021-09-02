using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaxiService.DataLayer;

namespace TaxiService.BusinessLayer
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICarRepository _carRepository;
        public OrderService(IOrderRepository orderRepository, ICarRepository carRepository)
        {
            _orderRepository = orderRepository;
            _carRepository = carRepository;
        }
        public Order Order { get; set; }
        public Car Car { get; set; }
        public async Task<Order> GetOrder(int? id)
        {
            if (id == -1)
            {
                Order = new Order { OrderDate = default(DateTime), OrderAddressDestination = "", OrderAddressSource = "", OrderStatus = "" };
            }

            Order = await _orderRepository.GetOrderById(id);
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
                    return _orderRepository.GetWaitingOrder();

                case 3:
                    return _orderRepository.GetOrder();
            }
            return null;

        }

        public async Task AddOrder(Order order)
        {
            if (order.OrderId == 0)
            {
                order.OrderStatus = "waiting";
                await _orderRepository.AddOrder(order);
            }
            else if (order.OrderId > 0)
            {
                var OrderDb = await _orderRepository.GetOrderById(order.OrderId);
                OrderDb.OrderComplateDate = order.OrderComplateDate;
                OrderDb.OrderStatus = "done";
                await _orderRepository.SaveChanges();
            }
        }
        public async Task AddOrder(Order order, int carselectedID)
        {
            var car = await _carRepository.GetCarById(carselectedID);
            var orderDb = await _orderRepository.GetOrderById(order.OrderId);
            orderDb.Car = car;
            orderDb.OrderStatus = "in progress";
            await _orderRepository.SaveChanges();
        }
        public async Task DelOrder(Order order)
        {
            var orderDel = await _orderRepository.GetOrderById(order.OrderId);
            if (orderDel != null)
            {
                await _orderRepository.DelOrder(orderDel);
            }
        }
    }
}
