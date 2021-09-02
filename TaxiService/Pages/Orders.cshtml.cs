using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TaxiService.BusinessLayer;
using TaxiService.DataLayer;

namespace TaxiService.Pages
{
    public class OrdersModel : PageModel
    {
        private readonly IOrderService _orderService;
        public List<Order> Order{ get; set; }

        public OrdersModel(IOrderService orderService)
        {
            _orderService = orderService;
        }
        public void OnGet()
        {
            Order = _orderService.GetOrder(3);
        }
    }
}
