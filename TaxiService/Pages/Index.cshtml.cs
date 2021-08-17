using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiService.Pages
{
    public class IndexModel : PageModel
    {
        //private readonly ILogger<IndexModel> _logger;
        private readonly TaxiContext _context;
        public List<Car> CarFree { get; set; }
        public List<Car> CarNotFree { get; set; }
        public List<Order> Order { get; set; }
        public IndexModel(TaxiContext db)
        {
            _context = db;
        }

        public void OnGet()
        {
            CarNotFree = _context.Order.Join(_context.Car,  o => o.Car.CarID, c => c.CarID,  ( o,c ) => o.Car).ToList();
            CarFree= _context.Car.GroupJoin(_context.Order, c => c.CarID, o => o.Car.CarID, ( c,o) => new { c,o }).SelectMany(x=>x.o.DefaultIfEmpty(), (car, order) 
                => new { car.c, ProductName = order == null ? -1 : order.OrderId}).Where(o=>o.ProductName == -1).Select(c=>c.c ).ToList();
            Order = _context.Order.Where(o => o.OrderStatus == "waiting").ToList();
        }
    }
}
