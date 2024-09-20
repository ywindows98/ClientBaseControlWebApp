﻿using ClientBaseControlWebApp.Data;
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
        public async Task<IActionResult> Create([Bind("Name,Surname,Birthday,InitialComment,NumberOfProcedures,HasAllergy,AllergiesComment,MainComment,Email,PhoneNumber,IndicationColor")] Client client)
        {
            if (!ModelState.IsValid)
            {
                return View(client);
            }
            Appearance appearance = new Appearance
            {
                ClientId = client.Id
            };

            client.AppearanceId = appearance.Id;

            await _clientsService.AddAsync(client);
			await _appearancesService.AddAsync(appearance);
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
		public async Task<IActionResult> EditAppearance(int id, [Bind("Id,SkinType,EyeColor,HairColor,MembraneColor,NeedleType,Comment,ClientId,CirclesUnderEyesColor,HasCapillaries,HasTan")] Appearance appearance)
		{
			if (!ModelState.IsValid)
			{
                Client client = await _clientsService.GetByIdAsync(appearance.ClientId);

				ClientViewModel viewModel = new ClientViewModel
				{
					Client = client,
					Appearance = appearance
				};

				return View("Details", viewModel);
			}
			await _appearancesService.AddAsync(appearance);
			return RedirectToAction("Details", new { id = appearance.ClientId });
		}

		public async Task<IActionResult> Edit(int id)
		{
            var client = await _clientsService.GetByIdAsync(id);
            if (client == null) return View("NotFound");
			return View(client);
		}
		[HttpPost]
		public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Surname,Birthday,InitialComment,NumberOfProcedures,HasAllergy,AllergiesComment,MainComment,Email,PhoneNumber,IndicationColor")] Client client)
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

			await _clientsService.DeleteAsync(id);
			return RedirectToAction(nameof(Index));
		}
	}
}
