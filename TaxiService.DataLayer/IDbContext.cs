using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace TaxiService.DataLayer
{
    public interface IDbContext
        {
            DbSet<Car> Car { get; set; }
            DbSet<Order> Order { get; set; }

        Task SaveChanges();
    }
}
