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
        Task<Car> GetCarAsync(int? id);
        Task<List<Car>> GetFreeCarsAsync();
        Task<List<Car>> GetNotFreeCarsAsync();
        Task<List<Car>> GetAllCarsAsync();
        Task AddCarAsync(Car car);
    }
}
