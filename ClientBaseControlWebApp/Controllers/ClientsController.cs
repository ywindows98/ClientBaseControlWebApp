using ClientBaseControlWebApp.Data;
using ClientBaseControlWebApp.Data.Services;
using ClientBaseControlWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClientBaseControlWebApp.Controllers
{
    public class ClientsController : Controller
    {
        private readonly ClientsService _service;
        public ClientsController(ClientsService service)
        {
            _service = service;
        }

        //[Authorize]
        public async Task<IActionResult> Index(string searchValue)
        {
            IEnumerable<Client> data;

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
        public async Task<IActionResult> Create([Bind("Name,Surname,Birthday,InitialComment,NumberOfProcedures,HasAllergy,AllergiesComment,MainComment,Email,PhoneNumber,IndicationColor")] Client client)
        {
            if (!ModelState.IsValid)
            {
                return View(client);
            }
            await _service.AddAsync(client);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var client = await _service.GetByIdAsync(id);

            if(client == null)
            {
                return View();
            }

            return View(client);
        }

		public async Task<IActionResult> Edit(int id)
		{
            var client = await _service.GetByIdAsync(id);
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
			await _service.UpdateAsync(id, client);
			return RedirectToAction(nameof(Index));
		}

       
		public async Task<IActionResult> Delete(int id)
		{
            var client = await _service.GetByIdAsync(id);
            if (client == null) return View("NotFound");
            return View(client);
		}

		[HttpPost, ActionName("Delete")]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var client = await _service.GetByIdAsync(id);
			if (client == null) return View("NotFound");

			await _service.DeleteAsync(id);
			return RedirectToAction(nameof(Index));
		}
	}
}
