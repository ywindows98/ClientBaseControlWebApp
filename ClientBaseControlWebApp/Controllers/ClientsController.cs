using ClientBaseControlWebApp.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClientBaseControlWebApp.Controllers
{
    public class ClientsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ClientsController(ApplicationDbContext context)
        {
            _context = context;
        }

        //[Authorize]
        public IActionResult Index()
        {
            var data = _context.Clients.ToList();
            return View(data);
        }
    }
}
