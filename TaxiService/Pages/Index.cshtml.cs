using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxiService.BusinessLayer;
using TaxiService.DataLayer;

namespace TaxiService.Pages
{
    public class IndexModel : PageModel
    {
        private readonly TaxiContext _context;
        private readonly BusinessLogic _busLogic;
        public List<Car> CarFree { get; set; }
        public List<Car> CarNotFree { get; set; }
        public List<Order> Order { get; set; }
        public IndexModel(TaxiContext db)
        {
            _context = db;
            _busLogic = new BusinessLogic(_context);
        }

        public void OnGet()
        {
            CarNotFree = _busLogic.GetCar(2);
            CarFree= _busLogic.GetCar(1);
            Order = _busLogic.GetOrder(2);
        }
    }
}
