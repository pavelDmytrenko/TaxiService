using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiService.DataLayer
{
    public interface ICarRepository
    {
        List<Car> GetFreeCars();
        List<Car> GetNotFreeCars();
        List<Car> GetCars();
        Task<Car> GetCarById(int? id);
        Task AddCar(Car car);
        Task SaveChanges();
    }
}
