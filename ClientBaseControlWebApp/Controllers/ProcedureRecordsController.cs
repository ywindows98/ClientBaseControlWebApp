using ClientBaseControlWebApp.Data.Services;
using ClientBaseControlWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClientBaseControlWebApp.Controllers
{
	public class ProcedureRecordsController : Controller
	{
		private readonly ProcedureRecordsService _service;

		public ProcedureRecordsController(ProcedureRecordsService service)
		{
			_service = service;
		}
		public async Task<IActionResult> Index(string searchValue)
		{
			IEnumerable<ProcedureRecord> data;

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
		public async Task<IActionResult> Create([Bind("Date,Comment,ClientId,ProcedureTypeId")] ProcedureRecord procedureRecord)
		{
			if (!ModelState.IsValid)
			{
				return View(procedureRecord);
			}
			await _service.AddAsync(procedureRecord);
			return RedirectToAction(nameof(Index));
		}

		public async Task<IActionResult> Details(int id)
		{
			var procedureRecord = await _service.GetByIdAsync(id);

			if (procedureRecord == null)
			{
				return View();
			}

			return View(procedureRecord);
		}

		public async Task<IActionResult> Edit(int id)
		{
			var procedureRecord = await _service.GetByIdAsync(id);
			if (procedureRecord == null) return View("NotFound");
			return View(procedureRecord);
		}
		[HttpPost]
		public async Task<IActionResult> Edit(int id, [Bind("Id,Date,Comment,ClientId,ProcedureTypeId")] ProcedureRecord procedureRecord)
		{
			if (!ModelState.IsValid)
			{
				return View(procedureRecord);
			}
			await _service.UpdateAsync(id, procedureRecord);
			return RedirectToAction(nameof(Index));
		}


		public async Task<IActionResult> Delete(int id)
		{
			var procedureRecord = await _service.GetByIdAsync(id);
			if (procedureRecord == null) return View("NotFound");
			return View(procedureRecord);
		}

		[HttpPost, ActionName("Delete")]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var procedureRecord = await _service.GetByIdAsync(id);
			if (procedureRecord == null) return View("NotFound");

			await _service.DeleteAsync(id);
			return RedirectToAction(nameof(Index));
		}
	}
}
