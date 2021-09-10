using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TaxiService.BusinessLayer;
using TaxiService.DataLayer;

namespace TaxiService.Pages
{
    public class OrderProgressModel : PageModel
    {
        private readonly IOrderService _orderService;
        [BindProperty]
        public Order Order { get; set; }

        public OrderProgressModel(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Order = await _orderService.GetOrderAsync(id);
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            await _orderService.AddOrderAsync(Order);
            return RedirectToPage("Orders");
        }

    }
}
