using CarRent.Core.Core.Repositories;
using System.Threading.Tasks;

namespace CarRent.Core.Core
{
    public interface IUnitOfWork
    {
        ICarRepository Cars { get; }

        Task<int> Complete();
    }
}
