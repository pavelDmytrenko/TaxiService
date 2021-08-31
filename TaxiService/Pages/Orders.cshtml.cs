using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TaxiService.BusinessLayer;
using TaxiService.DataLayer;

namespace TaxiService.Pages
{
    public class OrdersModel : PageModel
    {
        private readonly TaxiContext _context;
        private readonly BusinessLogic _busLogic;
        public List<Order> Order{ get; set; }

        public OrdersModel(TaxiContext db)
        {
            _context = db;
            _busLogic = new BusinessLogic(_context);
        }
        public void OnGet()
        {
            Order = _busLogic.GetOrder(3);
        }
    }
}
