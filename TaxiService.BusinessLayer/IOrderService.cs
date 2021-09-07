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
        Task<Order> GetOrder(int? id);
        List<Order> GetOrders();
        List<Order> GetWaitingOrders();
        Task AddOrder(Order order);
        Task AddOrder(Order order, int carselectedID);
        Task DelOrder(Order order);


    }
}
