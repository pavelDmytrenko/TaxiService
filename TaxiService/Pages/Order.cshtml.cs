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
    public class OrderModel : PageModel
    {
        private readonly TaxiContext _context;
        private readonly BusinessLogic _busLogic;
        [BindProperty]
        public  Order Order { get; set; }

        public OrderModel(TaxiContext db)
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

            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            await _busLogic.AddOrder(Order);
            return RedirectToPage("Orders");

        }
    }
}
