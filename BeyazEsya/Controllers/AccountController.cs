using BeyazEsya.Dto;
using BeyazEsya.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BeyazEsya.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        public AccountController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            var user=_userManager.FindByNameAsync(User.Identity.Name).Result;
            if(user!=null)
            {
                var model = new UserProfilView
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    City = user.City,
                    Email = user.Email,
                    UserName = user.UserName,
                    Password = user.PasswordHash,
                    ConfirmPassword = user.PasswordHash
                };
                return View(model);
            }
            else
            {
                return RedirectToAction("Login","Account");
            }
            return View();
        }
        [HttpPost]
        public IActionResult Edit(UserProfilView model)
        {
            var user = _userManager.FindByNameAsync(User.Identity.Name).Result;
            if (user != null)
            {
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.City = model.City;
                user.Email = model.Email;
                user.UserName = model.UserName;
              
                if(model.Password==model.ConfirmPassword)
                {
                    user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, model.Password);
                    var result = _userManager.UpdateAsync(user).Result;
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        foreach (var item in result.Errors)
                        {
                            ModelState.AddModelError("", item.Description);
                        }
                    }
                }

               
               
            }
            return View(model);
        }
    }
}
