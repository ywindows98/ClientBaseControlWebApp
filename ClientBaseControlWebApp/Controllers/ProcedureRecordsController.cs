using ClientBaseControlWebApp.Data.Services;
using ClientBaseControlWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Migrations;

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

		public async Task<IActionResult> Create(int clientId)
		{
			var viewModel = new ProcedureRecordViewModel
			{
				Date = DateTime.Now,
				AvailableMaterials = await _materialsService.GetAllAsync(),
				AvailableProcedureTypes = await _procedureTypesService.GetAllAsync(),
				ClientId = clientId,
				Client = await _clientsService.GetByIdAsync(clientId)

			};
			return View(viewModel);
		}


		[HttpPost]
		
		public async Task<IActionResult> Create(ProcedureRecordViewModel model)
		{
		

			var procedureRecord = new ProcedureRecord
			{
				Date = model.Date,
				Comment = model.Comment,
				ClientId = model.ClientId,
				ProcedureTypeId = model.ProcedureTypeId
				
			};

			if (model.SelectedMaterialIds != null)
			{
				List<int> materialIds = model.SelectedMaterialIds.Split(',')
							 .Select(int.Parse)
							 .ToList();

				foreach (int materialId in materialIds)
				{
					procedureRecord.Records_Materials.Add(new Record_Material(procedureRecord.Id, materialId));
				}
			}
			

			if (!ModelState.IsValid)
			{
				var viewModel = new ProcedureRecordViewModel
				{
					AvailableMaterials = await _materialsService.GetAllAsync(),
					AvailableProcedureTypes = await _procedureTypesService.GetAllAsync(),
					Client = await _clientsService.GetByIdAsync(model.ClientId)


				};
				return View(viewModel);
			}

			await _procedureRecordsService.AddAsync(procedureRecord);
			return RedirectToAction("Details", "Clients", new {id = model.ClientId});
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

			List<int> materialIds = new List<int>();
			List<Material> selectedMaterials = new List<Material>();
			foreach(Record_Material rm in procedureRecord.Records_Materials)
			{
				materialIds.Add(rm.Material.Id);
				selectedMaterials.Add(rm.Material);
			}

			var viewModel = new ProcedureRecordViewModel
			{
				Id = procedureRecord.Id,
				Date = procedureRecord.Date,
				Comment = procedureRecord.Comment,
				ClientId = procedureRecord.ClientId,
				ProcedureTypeId = procedureRecord.ProcedureTypeId,
				SelectedMaterialIds = String.Join(",", materialIds),
				SelectedMaterials = selectedMaterials,
				AvailableMaterials = await _materialsService.GetAllAsync(),
				AvailableProcedureTypes = await _procedureTypesService.GetAllAsync(),
				Client = await _clientsService.GetByIdAsync(procedureRecord.ClientId)
			};

			return View(viewModel);
		}
		[HttpPost]
		public async Task<IActionResult> Edit(int id, ProcedureRecordViewModel viewModel)
		{

			var procedureRecord = new ProcedureRecord
			{
				Id = viewModel.Id,
				Date = viewModel.Date,
				Comment = viewModel.Comment,
				ClientId = viewModel.ClientId,
				ProcedureTypeId = viewModel.ProcedureTypeId,

			};

			if (viewModel.SelectedMaterialIds != null)
			{
				List<int> materialIds = viewModel.SelectedMaterialIds.Split(',')
							 .Select(int.Parse)
							 .ToList();

				foreach (int materialId in materialIds)
				{
					procedureRecord.Records_Materials.Add(new Record_Material(procedureRecord.Id, materialId));
				}
			}

			if (!ModelState.IsValid && !TryValidateModel(procedureRecord))
			{
				return View(viewModel);
			}

			await _procedureRecordsService.UpdateAsync(id, procedureRecord);
			return RedirectToAction("Details", "Clients", new { id = viewModel.ClientId });
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
