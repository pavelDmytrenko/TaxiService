using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiService
{
    public interface IDbContext
    {
        DbSet<Car> Car { get; set; }
        DbSet<Order> Order { get; set; }
    }
}
