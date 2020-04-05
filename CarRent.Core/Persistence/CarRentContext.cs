using CarRent.Core.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace CarRent.Core.Persistence
{
    public class CarRentContext : DbContext
    {
        public CarRentContext(DbContextOptions<CarRentContext> dbContextOptions) :
            base(dbContextOptions)
        {
        }

        public virtual DbSet<Car> Cars { get; set; }
    }
}
