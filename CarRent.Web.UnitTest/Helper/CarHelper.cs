using CarRent.Core.Core.Domain;
using CarRent.Web.ViewModels;
using System.Collections.Generic;

namespace CarRent.Web.UnitTest.Helper
{
    public static class CarHelper
    {
        public static IEnumerable<CarViewModel> GetViewModels()
        {
            return new List<CarViewModel>
            {
                new CarViewModel
                {
                    Id = 1,
                    Plate = "B2001ABC"
                },
                new CarViewModel
                {
                    Id = 2,
                    Plate = "B2002DEF"
                },
                new CarViewModel
                {
                    Id = 3,
                    Plate = "B2003GHI"
                },
            };
        }

        public static IEnumerable<Car> GetDomainModels()
        {
            return new List<Car>
            {
                new Car
                {
                    Id = 1,
                    Plate = "B2001ABC"
                },
                new Car
                {
                    Id = 2,
                    Plate = "B2002DEF"
                },
                new Car
                {
                    Id = 3,
                    Plate = "B2003GHI"
                },
            };
        }
    }
}
