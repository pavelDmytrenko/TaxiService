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
        private readonly ICarService _carService;
        public List<Car> Car { get; set; }

        public CarsModel(ICarService carService)
        {
            _carService = carService;
        }
        public void OnGet()
        {
            Car = _carService.GetCar(3);
        }
    }
}
