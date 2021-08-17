using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TaxiService.Pages
{
    public class CarsModel : PageModel
    {
        private readonly TaxiContext _context;
        public List<Car> Car { get; set; }

        public CarsModel(TaxiContext db)
        {
            _context = db;
        }
        public void OnGet()
        {
            Car = _context.Car.ToList();
        }
    }
}
