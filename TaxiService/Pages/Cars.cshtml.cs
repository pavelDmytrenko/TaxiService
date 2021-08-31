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
    public class CarsModel : PageModel
    {
        private readonly TaxiContext _context;
        private readonly BusinessLogic _busLogic;
        public List<Car> Car { get; set; }

        public CarsModel(TaxiContext db)
        {
            _context = db;
            _busLogic = new BusinessLogic(_context);
        }
        public void OnGet()
        {
            Car = _busLogic.GetCar(3);
        }
    }
}
