using BeyazEsya.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BeyazEsya.Controllers
{
    public class CustomerPanelController : Controller
    {
        public readonly UserManager<AppUser> _userManager;
        public CustomerPanelController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var user =await _userManager.Users.ToListAsync();
            
            return View(user);
        }
    }
}
