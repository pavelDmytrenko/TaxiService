using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<Order> GetOrderAsync(int? id)
        {
            return await _orderRepository.GetOrderByIdAsync(id); 
        }

        public async Task<List<Order>> GetOrdersAsync()
        {
            return await _orderRepository.GetOrderAsync();
        }
        public async Task<List<Order>> GetWaitingOrdersAsync()
        {
            return await _orderRepository.Orders.Where(o => o.OrderStatus == ((int)OrderStatus.Waiting)).ToListAsync();
        }

        public async Task AddOrderAsync(Order order)
        {
            if (order.OrderId == 0)
            {
                order.OrderStatus = ((int)OrderStatus.Waiting);
                await _orderRepository.AddOrderAsync(order);
            }
            else if (order.OrderId > 0)
            {
                var orderEntity = await _orderRepository.GetOrderByIdAsync(order.OrderId);
                orderEntity.OrderComplateDate = order.OrderComplateDate;
                orderEntity.OrderStatus = ((int)OrderStatus.Done);
                List<Car> carEntity = await _orderRepository.Orders.Where(o => o.OrderId == order.OrderId)
                                                                    .Join(_orderRepository.Cars, o => o.Car.CarID, c => c.CarID, (o, c) => o.Car)
                                                                    .ToListAsync();
                carEntity.First().CarReady = true;
                await _orderRepository.SaveChangesAsync();
            }
        }
        public async Task AddOrderAsync(Order order, int carselectedID)
        {
            var carEntity = await _carRepository.GetCarByIdAsync(carselectedID);
            var orderEntity = await _orderRepository.GetOrderByIdAsync(order.OrderId);
            orderEntity.Car = carEntity;
            orderEntity.Car.CarReady = false;
            orderEntity.OrderStatus = ((int)OrderStatus.InProgress);
            await _orderRepository.SaveChangesAsync();
        }
        public async Task DelOrderAsync(Order order)
        {
            var orderEntityDel = await _orderRepository.GetOrderByIdAsync(order.OrderId);
            if (orderEntityDel != null)
            {
                await _orderRepository.DelOrderAsync(orderEntityDel);
            }
        }
    }
}
