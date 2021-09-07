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
    public class OrderWaitingModel : PageModel
    {

        private readonly IOrderService _orderService;
        private readonly ICarService _carService;
        [BindProperty]
        public Order Order { get; set; }
        public List<Car> Car { get; set; }
        public OrderWaitingModel(IOrderService orderService, ICarService carService)
        {
            _orderService = orderService;
            _carService = carService;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
            return NotFound();
            }

            Order = await _orderService.GetOrder(id);
            Car = _carService.GetFreeCars();

            return Page();
        }
        public async Task<IActionResult> OnPostSubmit(int carselectedID)
        {
            await _orderService.AddOrder(Order, carselectedID);
            return RedirectToPage("Orders");
        }

        public async Task<IActionResult> OnPostDeleteAsync()
        {
            await _orderService.DelOrder(Order);
            return RedirectToPage("Orders");
        }

    }
}
