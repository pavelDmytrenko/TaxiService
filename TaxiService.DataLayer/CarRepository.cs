using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiService.DataLayer
{
    public class CarRepository : ICarRepository
    {
        private readonly IDbContext _context;
        public IQueryable<Car> Cars { get { return _context.Car; } }
        public IQueryable<Order> Orders { get { return _context.Order; } }
        public CarRepository(IDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<List<Car>> GetAllCarsAsync()
        {
            return await _context.Car.ToListAsync();
        }
        public async Task<Car> GetCarByIdAsync(int? id)
        {
            return await _context.Car.FindAsync(id);
        }
        public async Task AddCarAsync(Car car)
        {
            car.CarReady = true;
            _context.Car.Add(car);
            await _context.SaveChanges();
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChanges();
        }
    }
}
