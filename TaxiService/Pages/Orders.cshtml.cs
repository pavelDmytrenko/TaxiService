using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TaxiService.BusinessLayer;
using TaxiService.DataLayer;

namespace TaxiService.Pages
{
    public class OrdersModel : PageModel
    {
        private readonly IOrderService _orderService;

        public List<Order> Order{ get; set; }
        public int _inProgres = (int)OrderStatus.InProgress;
        public int _waiting = (int)OrderStatus.Waiting;
        public OrdersModel(IOrderService orderService)
        {
            _orderService = orderService;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            Order = await _orderService.GetOrdersAsync();
            return Page();
        }
    }
}
