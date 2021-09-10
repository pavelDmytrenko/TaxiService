using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace TaxiService.DataLayer
{
    public class TaxiContext : DbContext, IDbContext
    {
        public TaxiContext(DbContextOptions<TaxiContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>()
                .Property(b => b.CarReady)
                .HasDefaultValue(true);
        }

        public DbSet<Car> Car { get; set; }
        public DbSet<Order> Order { get; set; }
        public async Task SaveChanges()
        {
             await SaveChangesAsync();
        }
    }
}
