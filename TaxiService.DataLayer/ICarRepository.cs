using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiService.DataLayer
{
    public interface ICarRepository
    {
        IQueryable<Car> Cars { get; }
        IQueryable<Order> Orders { get; }
        Task<List<Car>> GetAllCarsAsync();
        Task<Car> GetCarByIdAsync(int? id);
        Task AddCarAsync(Car car);
        Task SaveChangesAsync();
    }
}
