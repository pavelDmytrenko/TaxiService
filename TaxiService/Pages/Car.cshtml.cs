using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TaxiService.BusinessLayer;
using TaxiService.DataLayer;

namespace TaxiService.Pages
{
    public class CarModel : PageModel
    {
        private readonly TaxiContext _context;
        private readonly BusinessLogic _busLogic;
        [BindProperty]
        public Car Car { get; set; }

        public CarModel(TaxiContext db)
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
            Car = await _busLogic.GetCar(id);

            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            await _busLogic.AddCar(Car);
            return RedirectToPage("Cars");
            
        }
    }
}
