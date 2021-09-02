using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiService.DataLayer
{
    public interface IOrderRepository
    {
        List<Order> GetWaitingOrder();
        List<Order> GetOrder();
        Task<Order> GetOrderById(int? id);
        Task AddOrder(Order order);
        Task DelOrder(Order order);
        Task SaveChanges();

    }
}
