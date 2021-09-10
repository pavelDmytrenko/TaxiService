using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiService.DataLayer
{
    public interface IOrderRepository
    {
        IQueryable<Order> Orders { get ; }
        IQueryable<Car> Cars { get; }
        Task<List<Order>> GetOrderAsync();
        Task<Order> GetOrderByIdAsync(int? id);
        Task AddOrderAsync(Order order);
        Task DelOrderAsync(Order order);
        Task SaveChangesAsync();

    }
}
