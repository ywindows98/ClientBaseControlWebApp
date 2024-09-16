using ClientBaseControlWebApp.Data.Services;
using ClientBaseControlWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ClientBaseControlWebApp.Controllers
{
	public class ProcedureRecordsController : Controller
	{
		private readonly ProcedureRecordsService _procedureRecordsService;
		private readonly MaterialsService _materialsService;
        private readonly ProcedureTypesService _procedureTypesService;
        private readonly ClientsService _clientsService;

        public ProcedureRecordsController(ProcedureRecordsService prservice, MaterialsService mService, ProcedureTypesService ptService, ClientsService cService)
		{
			_procedureRecordsService = prservice;
			_materialsService = mService;
			_procedureTypesService = ptService;
			_clientsService = cService;
		}
		public async Task<IActionResult> Index(string searchValue)
		{
			IEnumerable<ProcedureRecord> data;

			if (string.IsNullOrEmpty(searchValue))
			{
				data = await _procedureRecordsService.GetAllAsync();
			}
			else
			{
				data = await _procedureRecordsService.GetBySearchValue(searchValue);
			}

			return View(data);
		}

		public async Task<IActionResult> Create()
		{
            ViewBag.Clients = await _clientsService.GetAllAsync();
            ViewBag.ProcedureTypes = await _procedureTypesService.GetAllAsync();
            ViewBag.Materials = await _materialsService.GetAllAsync();
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Create([Bind("Date,Comment,ClientId,ProcedureTypeId")] ProcedureRecord procedureRecord, int[] selectedMaterials)
		{
			Material material;
			if(selectedMaterials != null)
			{
				foreach(int materialId in selectedMaterials)
				{
					material = await _materialsService.GetByIdAsync(materialId);
					if (material != null)
					{
						procedureRecord.Records_Materials.Add(new Record_Material(procedureRecord.Id, material.Id));
					}
				}
			}
			if (!ModelState.IsValid)
			{
                ViewBag.Clients = await _clientsService.GetAllAsync();
                ViewBag.ProcedureTypes = await _procedureTypesService.GetAllAsync();
                ViewBag.Materials = await _materialsService.GetAllAsync();
                return View(procedureRecord);
			}
			await _procedureRecordsService.AddAsync(procedureRecord);
			return RedirectToAction(nameof(Index));
		}

		public async Task<IActionResult> Details(int id)
		{
			var procedureRecord = await _procedureRecordsService.GetByIdAsync(id);

			if (procedureRecord == null)
			{
				return View();
			}

			return View(procedureRecord);
		}

		public async Task<IActionResult> Edit(int id)
		{
			var procedureRecord = await _procedureRecordsService.GetByIdAsync(id);
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
			await _procedureRecordsService.UpdateAsync(id, procedureRecord);
			return RedirectToAction(nameof(Index));
		}


		public async Task<IActionResult> Delete(int id)
		{
			var procedureRecord = await _procedureRecordsService.GetByIdAsync(id);
			if (procedureRecord == null) return View("NotFound");
			return View(procedureRecord);
		}

		[HttpPost, ActionName("Delete")]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var procedureRecord = await _procedureRecordsService.GetByIdAsync(id);
			if (procedureRecord == null) return View("NotFound");

			await _procedureRecordsService.DeleteAsync(id);
			return RedirectToAction(nameof(Index));
		}
	}
}
