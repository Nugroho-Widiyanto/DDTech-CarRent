using CarRent.Web.Services.Interfaces;
using CarRent.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace CarRent.Web.Controllers
{
    public class RentCalculatorController : Controller
    {
        private readonly IRentCalculatorService _service;

        public RentCalculatorController(IRentCalculatorService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Calculate(RentCalculatorViewModel viewModel)
        {
            var rentPrice = _service.Calculate(viewModel);
            return Json(rentPrice.ToString("C", CultureInfo.CurrentCulture));
        }
    }
}