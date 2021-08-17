using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TaxiService.Pages
{
    public class OrderWaitingModel : PageModel
    { 

        private readonly TaxiContext _context;
        [BindProperty]
        public Order Order { get; set; }
        public List<Car> Car { get; set; }
        public OrderWaitingModel(TaxiContext db)
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
        Car = _context.Car.GroupJoin(_context.Order, c => c.CarID, o => o.Car.CarID, (c, o) => new { c, o }).SelectMany(x => x.o.DefaultIfEmpty(), (car, order)
                  => new { car.c, ProductName = order == null ? -1 : order.OrderId }).Where(o => o.ProductName == -1).Select(c => c.c).ToList(); //_context.Car.ToList();
            return Page();
        }
        public async Task<IActionResult> OnPostSubmit(int carselectedID)
        {
            var car = await _context.Car.FindAsync(carselectedID);
            var orderDb = await _context.Order.FindAsync(Order.OrderId);
            orderDb.Car = car;
            orderDb.OrderStatus = "in progress";
            await _context.SaveChangesAsync();
            return RedirectToPage("Orders");
        }

        public async Task<IActionResult> OnPostDeleteAsync()
        {
            var order = await _context.Order.FindAsync(Order.OrderId);
            if (order != null)
                {
                    _context.Order.Remove(order);
                    await _context.SaveChangesAsync();
                }
            return RedirectToPage("Orders");
        }

    }
}
