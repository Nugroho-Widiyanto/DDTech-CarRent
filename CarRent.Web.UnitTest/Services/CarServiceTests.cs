using CarRent.Core.Core;
using CarRent.Core.Core.Domain;
using CarRent.Core.Core.Repositories;
using CarRent.Web.Services;
using CarRent.Web.Services.Interfaces;
using CarRent.Web.UnitTest.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.Web.UnitTest.Services
{
    [TestClass]
    public class CarServiceTests
    {
        private Mock<ICarRepository> _mockCarRepository;
        private Mock<IUnitOfWork> _mockUnitOfWork;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockCarRepository = new Mock<ICarRepository>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
        }

        [TestMethod]
        public async Task Get_WhenCarWithGivenIdExists_ShouldBeReturned()
        {
            //Arrange
            var id = 1;
            var expected = "B2001ABC";

            var car = new Car
            {
                Id = id,
                Plate = expected,
            };

            _mockCarRepository
                .Setup(x => x.Get(id))
                .Returns(Task.FromResult(CarHelper.GetDomainModels().FirstOrDefault(x => x.Id == id)))
                .Verifiable();

            _mockUnitOfWork.
                Setup(x => x.Cars).
                Returns(_mockCarRepository.Object);

            ICarService service = new CarService(_mockUnitOfWork.Object);

            //Act
            var actual = await service.Get(id);

            //Assert
            _mockCarRepository.Verify();
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected, actual.Plate);
        }
    }
}
