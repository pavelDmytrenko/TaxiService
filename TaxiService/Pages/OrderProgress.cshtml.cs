using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TaxiService.Pages
{
    public class OrderProgressModel : PageModel
    {
        private readonly TaxiContext _context;
        [BindProperty]
        public Order Order { get; set; }

        public OrderProgressModel(TaxiContext db)
        {
            _context = db;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Order = await _context.Order.FindAsync(id);

            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            var OrderDb = await _context.Order.FindAsync(Order.OrderId);
            OrderDb.OrderComplateDate = Order.OrderComplateDate;
            OrderDb.OrderStatus = "done";
            await _context.SaveChangesAsync();
            return RedirectToPage("Orders");
        }

    }
}
