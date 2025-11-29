using Microsoft.AspNetCore.Mvc;

namespace BeyazEsya.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
