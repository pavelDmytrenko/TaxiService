using Microsoft.EntityFrameworkCore;

namespace TaxiService.DataLayer
{
    public interface IDbContext
        {
            DbSet<Car> Car { get; set; }
            DbSet<Order> Order { get; set; }
        }
}
