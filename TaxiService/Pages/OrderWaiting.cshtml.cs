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

        private readonly TaxiContext _context;
        private readonly BusinessLogic _busLogic;
        [BindProperty]
        public Order Order { get; set; }
        public List<Car> Car { get; set; }
        public OrderWaitingModel(TaxiContext db)
        {
            _context = db;
            _busLogic = new BusinessLogic(_context);
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
            return NotFound();
            }

            Order = await _busLogic.GetOrder(id);
            Car = _busLogic.GetCar(1);

            return Page();
        }
        public async Task<IActionResult> OnPostSubmit(int carselectedID)
        {
            await _busLogic.AddOrder(Order, carselectedID);
            return RedirectToPage("Orders");
        }

        public async Task<IActionResult> OnPostDeleteAsync()
        {
            await _busLogic.DelOrder(Order);
            return RedirectToPage("Orders");
        }

    }
}
