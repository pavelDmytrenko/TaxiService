using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiService.DataLayer;
using static TaxiService.BusinessLayer.OrderService;

namespace TaxiService.BusinessLayer
{
    public interface IOrderService
    {
        Task<Order> GetOrderAsync(int? id);
        Task<List<Order>> GetOrdersAsync();
        Task<List<Order>> GetWaitingOrdersAsync();
        Task AddOrderAsync(Order order);
        Task AddOrderAsync(Order order, int carselectedID);
        Task DelOrderAsync(Order order);


    }
}
