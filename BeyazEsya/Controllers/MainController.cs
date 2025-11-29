using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BeyazEsya.Controllers
{
    public class MainController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}
