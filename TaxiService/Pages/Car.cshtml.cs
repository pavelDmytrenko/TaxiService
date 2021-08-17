using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace TaxiService.Pages
{
    public class CarModel : PageModel
    {
        private readonly TaxiContext _context;
        [BindProperty]
        public Car Car { get; set; }

        public CarModel(TaxiContext db)
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
                Car = new Car { CarNumber = "", CarModel = "", CarDriverFIO=""};
            }

            Car = await _context.Car.FindAsync(id);

            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            var CarDb = await _context.Car.FindAsync(Car.CarID);
            if (CarDb == null)
            {
                _context.Car.Add(Car);
                await _context.SaveChangesAsync();
            }
            else
            {
                CarDb.CarNumber = Car.CarNumber;
                CarDb.CarModel = Car.CarModel;
                CarDb.CarDriverFIO = Car.CarDriverFIO;
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("Cars");
            
        }
    }
}
