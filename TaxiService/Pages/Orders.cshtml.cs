using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TaxiService.Pages
{
    public class OrdersModel : PageModel
    {
        private readonly TaxiContext _context;
        public List<Order> Order{ get; set; }

        public OrdersModel(TaxiContext db)
        {
            _context = db;
        }
        public void OnGet()
        {
            Order = _context.Order.ToList();
        }
    }
}
