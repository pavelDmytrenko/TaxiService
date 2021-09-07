using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiService.DataLayer
{
    public class CarRepository : ICarRepository
    {
        private readonly IDbContext _context;
        public enum OrderStatus
        {
            Waitnig = 2,
            Done = 3
        }
        public CarRepository(IDbContext dbContext)
        {
            _context = dbContext;
        }
        public List<Car> GetFreeCars()
        {
            return _context.Car.GroupJoin(_context.Order, c => c.CarID, o => o.Car.CarID, (c, o) => new { c, o }).SelectMany(x => x.o.DefaultIfEmpty(), (car, order)
                    => new { car.c, ProductName = ((order == null)||(order.OrderStatus == ((int)OrderStatus.Done))) ? -1 : order.OrderId }).Where(o => o.ProductName == -1).Select(c => c.c).ToList();
        }
        public List<Car> GetNotFreeCars()
        {
            return _context.Order.Where(o=>o.OrderStatus != ((int)OrderStatus.Done)).Join(_context.Car, o => o.Car.CarID, c => c.CarID, (o, c) => o.Car).ToList();
        }
        public List<Car> GetCars()
        {
            return _context.Car.ToList();
        }
        public async Task<Car> GetCarById(int? id)
        {
            return await _context.Car.FindAsync(id);
        }
        public async Task AddCar(Car car)
        {
            _context.Car.Add(car);
            await _context.SaveChanges();
        }
        public async Task SaveChanges()
        {
            await _context.SaveChanges();
        }
    }
}
