using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TaxiService.BusinessLayer;
using TaxiService.DataLayer;

namespace TaxiService.Pages
{
    public class CarModel : PageModel
    {
        private readonly ICarService _carService;
        [BindProperty]
        public Car Car { get; set; }

        public CarModel(ICarService carService)
        {
            _carService = carService;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Car = await _carService.GetCarAsync(id);

            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            await _carService.AddCarAsync(Car);
            return RedirectToPage("Cars");
            
        }
    }
}
