using CarRent.Web.ViewModels;

namespace CarRent.Web.Services.Interfaces
{
    public interface IRentCalculatorService
    {
        double Calculate(RentCalculatorViewModel viewModel);
    }
}
