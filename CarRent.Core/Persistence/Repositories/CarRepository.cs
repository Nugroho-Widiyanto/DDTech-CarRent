using CarRent.Core.Core.Domain;
using CarRent.Core.Core.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace CarRent.Core.Persistence.Repositories
{
    public class CarRepository : Repository<Car>, ICarRepository
    {
        public CarRepository(CarRentContext context)
            : base(context)
        {
        }

        public IEnumerable<Car> GetTopRentedCars(int count)
        {
            return CarRentalContext.Cars.OrderByDescending(c => c.Year).Take(count).ToList();
        }

        public CarRentContext CarRentalContext
        {
            get { return Context as CarRentContext; }
        }
    }
}
