using BeyazEsya.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BeyazEsya.Controllers
{
    public class LogoutController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        public LogoutController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }
        public async Task<IActionResult> Index()
        {
            await _signInManager.SignOutAsync();
            TempData["Mesaj"] = "Başarılı Şekilde Çıkış Yapınız";
            return RedirectToAction("Index", "Home");
        }
    }
}
