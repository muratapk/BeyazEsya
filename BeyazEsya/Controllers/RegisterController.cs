using BeyazEsya.Dto;
using BeyazEsya.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BeyazEsya.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(RegisterDto gelen)
        {
            Random rnd=new Random();
            int code=rnd.Next(100000,999909);

            AppUser appUser = new AppUser()
            {
                FirstName = gelen.FirstName,
                LastName = gelen.LastName,
                City = gelen.City,
                UserName = gelen.UserName,
                Email = gelen.Email,
                ConfirmCode = code

            };
            

            var result =  _userManager.CreateAsync(appUser,gelen.Password).Result;
            if(result.Succeeded)
            {
                //kayıt başarılı
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
    }
}
