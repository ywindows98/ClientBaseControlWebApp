using ClientBaseControlWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using ClientBaseControlWebApp.Data.Services;

namespace ClientBaseControlWebApp.Controllers
{
    public class ProcedureTypesController : Controller
    {
        private readonly ProcedureTypesService _service;
        public ProcedureTypesController(ProcedureTypesService service)
        {
            _service = service;
        }

        //[Authorize]
        public async Task<IActionResult> Index(string searchValue)
        {
            IEnumerable<ProcedureType> data;

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

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name")] ProcedureType procedureType)
        {
            if (!ModelState.IsValid)
            {
                return View(procedureType);
            }
            await _service.AddAsync(procedureType);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var procedureType = await _service.GetByIdAsync(id);
            if (procedureType == null) return View("NotFound");
            return View(procedureType);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] ProcedureType procedureType)
        {
            if (!ModelState.IsValid)
            {
                return View(procedureType);
            }
            await _service.UpdateAsync(id, procedureType);
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Delete(int id)
        {
            var procedureType = await _service.GetByIdAsync(id);
            if (procedureType == null) return View("NotFound");
            return View(procedureType);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var procedureType = await _service.GetByIdAsync(id);
            if (procedureType == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
