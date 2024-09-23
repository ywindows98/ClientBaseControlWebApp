using ClientBaseControlWebApp.Data;
using ClientBaseControlWebApp.Data.Services;
using ClientBaseControlWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClientBaseControlWebApp.Controllers
{
    public class ClientsController : Controller
    {
        private readonly ClientsService _clientsService;
		private readonly AppearancesService _appearancesService;
		public ClientsController(ClientsService clientsService, AppearancesService appearancesService)
        {
            _clientsService = clientsService;
            _appearancesService = appearancesService;
        }

        //[Authorize]
        public async Task<IActionResult> Index(string searchValue)
        {
            IEnumerable<Client> data;

			if (string.IsNullOrEmpty(searchValue))
            {
                data = await _clientsService.GetAllAsync();
            }
            else
            {
                data = await _clientsService.GetBySearchValue(searchValue);
            }
            
            return View(data);
        }

		public IActionResult Create()
		{
			return View();
		}
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name,Surname,Birthday,InitialComment,NumberOfProcedures,HasAllergy,AllergiesComment,MainComment,Email,PhoneNumber,IndicationColor")] Client client, [Bind("SkinType,EyeColor,HairColor,HasCapillaries,CirclesUnderEyesColor,HasTan,MembraneColor,NeedleType,Comment")] Appearance appearance)
        {
            if (!ModelState.IsValid)
            {
                return View(client);
            }

			client.Appearance = appearance;
			appearance.Client = client;

			await _clientsService.AddAsync(client);
			return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var client = await _clientsService.GetByIdAsync(id);

            if(client == null)
            {
                return NotFound();
            }

            ClientViewModel viewModel = new ClientViewModel
            {
                Client = client,
                Appearance = client.Appearance
            };

            return View(viewModel);
        }


		[HttpPost]
		[ActionName("Details")]
		//[Bind("Id,SkinType,EyeColor,HairColor,MembraneColor,NeedleType,Comment,CirclesUnderEyesColor,HasCapillaries,HasTan")]
		public async Task<IActionResult> EditAppearance(int id, Appearance appearance)
		{
			if (!ModelState.IsValid)
			{
				Client client = await _clientsService.GetByIdAsync(id);

				ClientViewModel viewModel = new ClientViewModel
				{
					Client = client,
					Appearance = appearance
				};

				return View("Details", viewModel);
			}
			await _appearancesService.UpdateAsync(appearance.Id, appearance);
			return RedirectToAction("Details", new { id });
		}

		public async Task<IActionResult> Edit(int id)
		{
            var client = await _clientsService.GetByIdAsync(id);
            if (client == null) return View("NotFound");
			return View(client);
		}
		[HttpPost]
		public async Task<IActionResult> Edit(int id, [Bind("Id,AppearanceId,Name,Surname,Birthday,InitialComment,NumberOfProcedures,HasAllergy,AllergiesComment,MainComment,Email,PhoneNumber,IndicationColor")] Client client)
		{
			if (!ModelState.IsValid)
			{
				return View(client);
			}
			await _clientsService.UpdateAsync(id, client);


			return RedirectToAction("Details", new { id });
		}

       
		public async Task<IActionResult> Delete(int id)
		{
            var client = await _clientsService.GetByIdAsync(id);
            if (client == null) return View("NotFound");
            return View(client);
		}

		[HttpPost, ActionName("Delete")]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var client = await _clientsService.GetByIdAsync(id);
			if (client == null) return View("NotFound");

			if (client.AppearanceId!=null)
			{
				await _appearancesService.DeleteAsync((int)client.AppearanceId);
			}
			
			await _clientsService.DeleteAsync(id);

			return RedirectToAction(nameof(Index));
		}
	}
}
