using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiService.DataLayer
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IDbContext _context;
        public enum OrderStatus
        {
            Waitnig = 2,
            Done = 3
        }
        public OrderRepository(IDbContext dbContext)
        {
            _context = dbContext;
        }
        public List<Order> GetWaitingOrder()
        {
            return _context.Order.Where(o => o.OrderStatus == ((int)OrderStatus.Waitnig)).ToList();
        }

        public List<Order> GetOrder()
        {
            return _context.Order.ToList();
        }

        public async Task<Order> GetOrderById(int? id)
        {
            return await _context.Order.FindAsync(id);
        }
        public async Task AddOrder(Order order)
        {
            _context.Order.Add(order);
            await _context.SaveChanges();
        }
        public async Task DelOrder(Order order)
        {
            _context.Order.Remove(order);
            await _context.SaveChanges();
        }
        public async Task SaveChanges()
        {
            await _context.SaveChanges();
        }
    }
}
