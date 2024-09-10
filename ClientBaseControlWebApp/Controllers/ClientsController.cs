using ClientBaseControlWebApp.Data;
using ClientBaseControlWebApp.Data.Services;
using ClientBaseControlWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClientBaseControlWebApp.Controllers
{
    public class ClientsController : Controller
    {
        private readonly IClientsService _service;
        public ClientsController(IClientsService service)
        {
            _service = service;
        }

        //[Authorize]
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAll();
            return View(data);
        }

		public IActionResult Create()
		{
			return View();
		}
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name,Surname,Birthday,InitialComment,NumberOfProcedures,AllergiesComment,MainComment,Email,PhoneNumber,IndicationColor")] Client client)
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
    }
}
