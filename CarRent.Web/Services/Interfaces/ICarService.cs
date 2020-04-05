using CarRent.Web.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarRent.Web.Services.Interfaces
{
    public interface ICarService
    {
        Task Add(CarViewModel viewModel);

        Task<IEnumerable<CarViewModel>> Get();

        Task<CarViewModel> Get(int id);

        Task Remove(int id);

        Task Save(CarViewModel viewModel);
    }
}
