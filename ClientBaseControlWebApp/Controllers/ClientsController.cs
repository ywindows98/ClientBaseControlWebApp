using Microsoft.AspNetCore.Mvc;

namespace ClientBaseControlWebApp.Controllers
{
    public class ClientsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
