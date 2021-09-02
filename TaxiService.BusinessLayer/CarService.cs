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
        public Car Car { get; set; }
        public async Task<Car> GetCar(int? id)
        {
            if (id == -1)
            {
                Car = new Car { CarNumber = "", CarModel = "", CarDriverFIO = "" };
            }
            Car = await _carContext.GetCarById(id);
            return Car;
        }
        /*         findStatus
        free cars -    1
        nofree cars -  2
        all cars    -  3
          */
        public List<Car> GetCar(int findStatus)
        {
            switch (findStatus)

            {
                case 1:
                    return _carContext.GetFreeCar();

                case 2:
                    return _carContext.GetNotFreeCar();

                case 3:
                    return _carContext.GetCars();
            }
            return null;
        }
        public async Task AddCar(Car car)
        {
            var CarDb = await _carContext.GetCarById(car.CarID);
            if (CarDb == null)
            {
                await _carContext.AddCar(car);
            }
            else
            {
                CarDb.CarNumber = car.CarNumber;
                CarDb.CarModel = car.CarModel;
                CarDb.CarDriverFIO = car.CarDriverFIO;
                await _carContext.SaveChanges();
            }
        }
    }
}
