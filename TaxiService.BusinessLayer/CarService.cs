using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiService.DataLayer;

namespace TaxiService.BusinessLayer
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carContext;
        public CarService(ICarRepository dbContext)
        {
            _carContext = dbContext;
        }
        public async Task<Car> GetCar(int? id)
        {
            return await _carContext.GetCarById(id);
        }
        public List<Car> GetFreeCars()
        {
            return _carContext.GetFreeCars();
        }
        public List<Car> GetNotFreeCars()
        {
            return _carContext.GetNotFreeCars();
        }
        public List<Car> GetAllCars()
        {
            return _carContext.GetCars();
        }

        public async Task AddCar(Car car)
        {
            var carEntity = await _carContext.GetCarById(car.CarID);
            if (carEntity == null)
            {
                await _carContext.AddCar(car);
            }
            else
            {
                carEntity.CarNumber = car.CarNumber;
                carEntity.CarModel = car.CarModel;
                carEntity.CarDriverFIO = car.CarDriverFIO;
                await _carContext.SaveChanges();
            }
        }
    }
}
