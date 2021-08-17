using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiService
{
    public class TaxiContext : DbContext, IDbContext
        {
            public TaxiContext(DbContextOptions<TaxiContext> options)
                : base(options)
            {
                Database.EnsureCreated();
            }

            public DbSet<Car> Car { get; set; }
            public DbSet<Order> Order { get; set; }

        }
    }

