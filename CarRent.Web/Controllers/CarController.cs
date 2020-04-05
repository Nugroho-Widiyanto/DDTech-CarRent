using CarRent.Core.Core.Domain;
using CarRent.Web.Services.Interfaces;
using CarRent.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CarRent.Web.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarService _service;

        public CarController(ICarService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var viewModel = _service.Get();
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult New()
        {
            var viewModel = new CarViewModel();
            return View("Form", viewModel);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var viewModel = _service.Get(id);

            if (viewModel == null)
                return NotFound();

            return View("Form", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(CarViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(nameof(Index));

            _service.Save(viewModel);
            return RedirectToAction("Index", "Car");
        }
    }
}
