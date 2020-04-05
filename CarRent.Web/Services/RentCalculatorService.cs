using CarRent.Web.Services.Interfaces;
using CarRent.Web.ViewModels;

namespace CarRent.Web.Services
{
    public class RentCalculatorService : IRentCalculatorService
    {
        public double Calculate(RentCalculatorViewModel viewModel)
        {
            double discountPercentage = 0;

            if (viewModel.Duration >= 3)
                discountPercentage += 5;

            if (viewModel.Cars >= 2)
                discountPercentage += 10;

            if (viewModel.Year.Year < 2010)
                discountPercentage += 7;

            double cost = viewModel.Price * viewModel.Duration * viewModel.Cars;
            double rentPrice = cost - (cost * discountPercentage / 100);

            return rentPrice;
        }
    }
}
