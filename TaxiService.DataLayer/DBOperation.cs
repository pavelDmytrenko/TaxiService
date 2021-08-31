
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiService.DataLayer
{
    public class DBOperation
    {
        private readonly TaxiContext _context;
        public DBOperation(TaxiContext dbContext)
        {
            _context = dbContext;
        }

        // getCar

        public List<Car> GetFreeCar()
        {
            return _context.Car.GroupJoin(_context.Order, c => c.CarID, o => o.Car.CarID, (c, o) => new { c, o }).SelectMany(x => x.o.DefaultIfEmpty(), (car, order)
                    => new { car.c, ProductName = order == null ? -1 : order.OrderId }).Where(o => o.ProductName == -1).Select(c => c.c).ToList();
        }
        public List<Car> GetNotFreeCar()
        {
            return _context.Order.Join(_context.Car, o => o.Car.CarID, c => c.CarID, (o, c) => o.Car).ToList();
        }
        public List<Car> GetCars()
        {
            return _context.Car.ToList();
        }
        public async Task<Car> GetCarById(int? id)
        {
            return await _context.Car.FindAsync(id);
        }

        // getOrder

        public List<Order> GetWaitingOrder()
        {
            return _context.Order.Where(o => o.OrderStatus == "waiting").ToList();
        }

        public List<Order> GetOrder()
        {
            return _context.Order.ToList();
        }

        public async Task<Order> GetOrderById(int? id)
        {
            return await _context.Order.FindAsync(id);
        }

        // AddCar
        public async Task AddCar(Car car)
        {
            _context.Car.Add(car);
            await _context.SaveChangesAsync();
        }

        //AddRemoveOrder
        public async Task AddOrder(Order order)
        {
            _context.Order.Add(order);
            await _context.SaveChangesAsync();
        }
        public async Task DelOrder(Order order)
        {
            _context.Order.Remove(order);
            await _context.SaveChangesAsync();
        }

        //Save Changes
        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
