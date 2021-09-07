using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiService.DataLayer;
using static TaxiService.BusinessLayer.CarService;

namespace TaxiService.BusinessLayer
{
    public interface ICarService
    {
        Task<Car> GetCar(int? id);
        List<Car> GetFreeCars();
        List<Car> GetNotFreeCars();
        List<Car> GetAllCars();
        Task AddCar(Car car);
    }
}
