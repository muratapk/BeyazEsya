using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using BeyazEsya.Models;
using BeyazEsya.Dto;
namespace BeyazEsya.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(LoginDto gelen)
        {
            var result = _signInManager.PasswordSignInAsync(gelen.UserName, gelen.Password, false, false).Result;
            if (result.Succeeded)
            {
                //giriş başarılı
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        public IActionResult SayfaBulunmadi()
        {
            return View();
        }
    }
}
