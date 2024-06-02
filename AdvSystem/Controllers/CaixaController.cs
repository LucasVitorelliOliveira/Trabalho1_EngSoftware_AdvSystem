using AdvSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AdvSystem.Controllers
{
    public class CaixaController : Controller
    {
        private readonly ILogger<CaixaController> _logger;

        public CaixaController(ILogger<CaixaController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
