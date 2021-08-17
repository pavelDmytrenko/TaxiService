using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TaxiService.Pages
{
    public class OrderModel : PageModel
    {
        private readonly TaxiContext _context;
        [BindProperty]
        public  Order Order { get; set; }

        public OrderModel(TaxiContext db)
        {
            _context = db;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (id == -1)
            {
                Order = new Order { OrderDate = default(DateTime), OrderAddressDestination = "", OrderAddressSource = "", OrderStatus = "" };
            }

            Order = await _context.Order.FindAsync(id);

            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            Order.OrderStatus = "waiting";
            _context.Order.Add(Order);
            await _context.SaveChangesAsync();
            return RedirectToPage("Orders");

        }
    }
}
