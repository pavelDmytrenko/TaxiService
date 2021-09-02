using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiService.DataLayer;

namespace TaxiService.BusinessLayer
{
    public interface ICarService
    {
        Car Car { get; set; }
        Task<Car> GetCar(int? id);
        List<Car> GetCar(int findStatus);
        Task AddCar(Car car);


    }
}
