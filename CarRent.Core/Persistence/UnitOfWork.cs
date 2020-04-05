using CarRent.Core.Core;
using CarRent.Core.Core.Repositories;
using CarRent.Core.Persistence.Repositories;
using System.Threading.Tasks;

namespace CarRent.Core.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CarRentContext _context;

        public ICarRepository Cars { get; private set; }

        public UnitOfWork(CarRentContext context)
        {
            _context = context;
            Cars = new CarRepository(_context);
        }

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
