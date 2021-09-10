using Microsoft.EntityFrameworkCore;
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
        private readonly ICarRepository _carRepository;
        public CarService(ICarRepository dbContext)
        {
            _carRepository = dbContext;
        }
        public async Task<Car> GetCarAsync(int? id)
        {
            return await _carRepository.GetCarByIdAsync(id);
        }
        public async Task<List<Car>> GetFreeCarsAsync()
        {
            return await _carRepository.Cars.Where(c => c.CarReady == true).ToListAsync();
        }
        public async Task<List<Car>> GetNotFreeCarsAsync()
        {
            return await _carRepository.Cars.Where(c => c.CarReady == false).ToListAsync();
        }
        public async Task<List<Car>> GetAllCarsAsync()
        {
            return await _carRepository.GetAllCarsAsync();
        }

        public async Task AddCarAsync(Car car)
        {
            var carEntity = await _carRepository.GetCarByIdAsync(car.CarID);
            if (carEntity == null)
            {
                await _carRepository.AddCarAsync(car);
            }
            else
            {
                carEntity.CarNumber = car.CarNumber;
                carEntity.CarModel = car.CarModel;
                carEntity.CarDriverFIO = car.CarDriverFIO;
                carEntity.CarReady = car.CarReady;
                await _carRepository.SaveChangesAsync();
            }
        }
    }
}
