using System.Diagnostics;
using BeyazEsya.Data;
using BeyazEsya.Models;
using Microsoft.AspNetCore.Mvc;

namespace BeyazEsya.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly EsyaDbContext _context;
        public HomeController(ILogger<HomeController> logger,EsyaDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        [HttpGet]
        public IActionResult UrunDetay(int id)
        {
            var result=_context.products.Where(x=>x.ProductId==id).FirstOrDefault();
            return View(result);
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
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
