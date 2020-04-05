using CarRent.Core.Core;
using CarRent.Core.Core.Domain;
using CarRent.Web.Services.Interfaces;
using CarRent.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.Web.Services
{
    //todo: add validation something went wrong
    public class CarService : ICarService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CarService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Add(CarViewModel viewModel)
        {
            var car = new Car
            {
                Capacity = viewModel.Capacity,
                Make = viewModel.Make,
                Model = viewModel.Model,
                Plate = viewModel.Plate,
                Year = viewModel.Year,
            };

            _unitOfWork.Cars.Add(car);
            await _unitOfWork.Complete();
        }

        public async Task<IEnumerable<CarViewModel>> Get()
        {
            var cars = await _unitOfWork.Cars.GetAll();
            var viewModels = new List<CarViewModel>();

            foreach (var car in cars)
            {
                viewModels.Add(new CarViewModel
                {
                    Capacity = car.Capacity,
                    Id = car.Id,
                    Make = car.Make,
                    Model = car.Model,
                    Plate = car.Plate,
                    Year = car.Year
                });
            }

            return viewModels;
        }

        public async Task<CarViewModel> Get(int id)
        {
            var car = await _unitOfWork.Cars.Get(id);

            if (car == default)
                return null;

            var viewModel = new CarViewModel
            {
                Capacity = car.Capacity,
                Id = car.Id,
                Make = car.Make,
                Model = car.Model,
                Plate = car.Plate,
                Year = car.Year
            };

            return viewModel;
        }

        public async Task Remove(int id)
        {
            var car = await _unitOfWork.Cars.Get(id);
            _unitOfWork.Cars.Remove(car);
            await _unitOfWork.Complete();
        }

        public async Task Save(CarViewModel viewModel)
        {
            if (viewModel.Id == 0)
            {
                var newCar = new Car
                {
                    Capacity = viewModel.Capacity,
                    Make = viewModel.Make,
                    Model = viewModel.Model,
                    Plate = viewModel.Plate,
                    Year = new DateTime(viewModel.Year.Year, 1, 1),
                };

                _unitOfWork.Cars.Add(newCar);
            }
            else
            {
                var existingCar = _unitOfWork.Cars.Find(x => x.Id == viewModel.Id).FirstOrDefault();
                existingCar.Capacity = viewModel.Capacity;
                existingCar.Make = viewModel.Make;
                existingCar.Model = viewModel.Model;
                existingCar.Plate = viewModel.Plate;
                existingCar.Year = new DateTime(viewModel.Year.Year, 1, 1);
            }

            await _unitOfWork.Complete();
        }
    }
}
