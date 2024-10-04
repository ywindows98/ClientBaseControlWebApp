using ClientBaseControlWebApp.Data.Services;
using ClientBaseControlWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClientBaseControlWebApp.Controllers
{
    public class MaterialsController : Controller
    {
        private readonly MaterialsService _service;
        public MaterialsController(MaterialsService service)
        {
            _service = service;
        }

        //[Authorize]
        public async Task<IActionResult> Index(string searchValue)
        {
            IEnumerable<Material> data;

            if (string.IsNullOrEmpty(searchValue))
            {
                data = await _service.GetAllAsync();
            }
            else
            {
                data = await _service.GetBySearchValue(searchValue);
            }

            return View(data);
        }

        public async Task<IActionResult> Create()
        {
			ViewBag.Materials = await _service.GetAllAsync();
			return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name,Description,Amount,UnitsOfMeasurement,MaterialType")] Material material)
        {
			ViewBag.Materials = await _service.GetAllAsync();
			if (!ModelState.IsValid)
            {
                return View(material);
            }

            await _service.AddAsync(material);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var material = await _service.GetByIdAsync(id);
			ViewBag.Materials = await _service.GetAllAsync();

			if (material == null)
            {
                return View();
            }

            return View(material);
        }

        public async Task<IActionResult> Edit(int id)
        {
			ViewBag.Materials = await _service.GetAllAsync();
			var material = await _service.GetByIdAsync(id);
            if (material == null) return View("NotFound");
			
			return View(material);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Amount,UnitsOfMeasurement,MaterialType")] Material material)
        {
			
			if (!ModelState.IsValid)
            {
				ViewBag.Materials = await _service.GetAllAsync();
				return View(material);
            }
            
            await _service.UpdateAsync(id, material);
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Delete(int id)
        {
			ViewBag.Materials = await _service.GetAllAsync();
			var material = await _service.GetByIdAsync(id);
            if (material == null) return View("NotFound");
            return View(material);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
			ViewBag.Materials = await _service.GetAllAsync();
			var material = await _service.GetByIdAsync(id);
            if (material == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
