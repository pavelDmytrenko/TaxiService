using Microsoft.EntityFrameworkCore;
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
        public IQueryable<Order> Orders { get { return _context.Order; } }
        public IQueryable<Car> Cars { get { return _context.Car; } }
        public OrderRepository(IDbContext dbContext)
        {
            _context = dbContext;
        }
        public async Task<List<Order>> GetOrderAsync()
        {
            return await _context.Order.ToListAsync();
        }

        public async Task<Order> GetOrderByIdAsync(int? id)
        {
            return await _context.Order.FindAsync(id);
        }
        public async Task AddOrderAsync(Order order)
        {
            _context.Order.Add(order);
            await _context.SaveChanges();
        }
        public async Task DelOrderAsync(Order order)
        {
            _context.Order.Remove(order);
            await _context.SaveChanges();
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChanges();
        }
    }
}
