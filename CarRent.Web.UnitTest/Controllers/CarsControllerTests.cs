using CarRent.Core.Core;
using CarRent.Core.Core.Repositories;
using CarRent.Web.Controllers;
using CarRent.Web.Services.Interfaces;
using CarRent.Web.UnitTest.Helper;
using CarRent.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.Web.UnitTest.Controllers
{
    [TestClass]
    public class CarsControllerTests
    {
        private CarsController _controller;
        private Mock<ICarService> _mockService;

        public CarsControllerTests()
        {
            var mockRepository = new Mock<ICarRepository>();
            var mockUoW = new Mock<IUnitOfWork>();
            mockUoW.SetupGet(x => x.Cars).Returns(mockRepository.Object);
            _mockService = new Mock<ICarService>();
            _controller = new CarsController(_mockService.Object);
        }

        #region Details Action

        [TestMethod]
        public async Task Details_WhenIdIsNotSupplied_ShouldReturnNotFound()
        {
            // Act
            var result = await _controller.Details(null);

            // Assert
            Xunit.Assert.IsType<NotFoundResult>(result);
        }

        [TestMethod]
        public async Task Details_WhenNoCarWithGivenIdExists_ShouldReturnNotFound()
        {
            // Arrange
            int? id = 99;

            _mockService
                .Setup(x => x.Get(id.Value))
                .Returns(Task.FromResult(CarHelper.GetViewModels().FirstOrDefault(x => x.Id == id.Value)));

            // Act
            var result = await _controller.Details(id);

            // Assert
            Xunit.Assert.IsType<NotFoundResult>(result);
        }

        [TestMethod]
        public async Task Details_WhenCarWithGivenIdExists_ShouldBeReturned()
        {
            // Arrange
            int? id = 1;

            _mockService
                .Setup(x => x.Get(id.Value))
                .Returns(Task.FromResult(CarHelper.GetViewModels().FirstOrDefault(x => x.Id == id.Value)));

            // Act
            var result = await _controller.Details(id) as ViewResult;

            // Assert
            var viewModel = result.ViewData.Model as CarViewModel;
            Xunit.Assert.NotNull(viewModel);
        }

        #endregion
    }
}
