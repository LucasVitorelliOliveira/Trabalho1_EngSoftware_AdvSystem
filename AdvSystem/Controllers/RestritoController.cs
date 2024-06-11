using AdvSystem.Filters;
using Microsoft.AspNetCore.Mvc;

namespace AdvSystem.Controllers
{
    [UsuarioLogado]
    public class RestritoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
