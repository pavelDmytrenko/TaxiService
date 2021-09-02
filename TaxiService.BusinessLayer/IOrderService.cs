using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiService.DataLayer;

namespace TaxiService.BusinessLayer
{
    public interface IOrderService
    {
        Order Order { get; set; }
        Task<Order> GetOrder(int? id);
        List<Order> GetOrder(int findStatus);
        Task AddOrder(Order order);
        Task AddOrder(Order order, int carselectedID);
        Task DelOrder(Order order);


    }
}
