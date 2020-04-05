using CarRent.Web.Services.Interfaces;
using CarRent.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CarRent.Web.Controllers
{
    public class CarsController : Controller
    {
        private readonly ICarService _service;

        public CarsController(ICarService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var viewModel = await _service.Get();
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var viewModel = await _service.Get(id.Value);

            if (viewModel == null)
                return NotFound();

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var viewModel = new CarViewModel();
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CarViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            await _service.Save(viewModel);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var viewModel = await _service.Get(id.Value);

            if (viewModel == null)
                return NotFound();

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CarViewModel viewModel)
        {
            if (id != viewModel.Id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(viewModel);

            await _service.Save(viewModel);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var viewModel = await _service.Get(id.Value);

            if (viewModel == null)
                return NotFound();

            return View(viewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.Remove(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
