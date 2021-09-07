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
        public enum OrderStatus
        {
            InProgress = 1,
            Waitnig = 2,
            Done = 3
        }
        public OrderService(IOrderRepository orderRepository, ICarRepository carRepository)
        {
            _orderRepository = orderRepository;
            _carRepository = carRepository;
        }

        public async Task<Order> GetOrder(int? id)
        {
            return await _orderRepository.GetOrderById(id); 
        }

        public List<Order> GetOrders()
        {
            return _orderRepository.GetOrder();
        }
        public List<Order> GetWaitingOrders()
        {
            return _orderRepository.GetWaitingOrder();
        }

        public async Task AddOrder(Order order)
        {
            if (order.OrderId == 0)
            {
                order.OrderStatus = ((int)OrderStatus.Waitnig);
                await _orderRepository.AddOrder(order);
            }
            else if (order.OrderId > 0)
            {
                var orderEntity = await _orderRepository.GetOrderById(order.OrderId);
                orderEntity.OrderComplateDate = order.OrderComplateDate;
                orderEntity.OrderStatus = ((int)OrderStatus.Done);
                await _orderRepository.SaveChanges();
            }
        }
        public async Task AddOrder(Order order, int carselectedID)
        {
            var carEntity = await _carRepository.GetCarById(carselectedID);
            var orderEntity = await _orderRepository.GetOrderById(order.OrderId);
            orderEntity.Car = carEntity;
            orderEntity.OrderStatus = ((int)OrderStatus.InProgress);
            await _orderRepository.SaveChanges();
        }
        public async Task DelOrder(Order order)
        {
            var orderEntityDel = await _orderRepository.GetOrderById(order.OrderId);
            if (orderEntityDel != null)
            {
                await _orderRepository.DelOrder(orderEntityDel);
            }
        }
    }
}
