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
        private readonly IOrderService _orderService;
        private readonly ICarService _carService;
        public List<Car> CarFree { get; set; }
        public List<Car> CarNotFree { get; set; }
        public List<Order> Order { get; set; }
        public IndexModel(ICarService carService,IOrderService orderService)
        {
            _orderService = orderService;
            _carService = carService;
        }

        public void OnGet()
        {
            CarNotFree = _carService.GetNotFreeCars();
            CarFree= _carService.GetFreeCars();
            Order = _orderService.GetWaitingOrders();
        }
    }
}
