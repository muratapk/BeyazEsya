using BeyazEsya.Data;
using BeyazEsya.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BeyazEsya.Component
{
    public class SepetList:ViewComponent
    {
        private readonly EsyaDbContext _context;
        private readonly CartHelper _cardHelp;
        private readonly UserManager<AppUser> _userManager;
        public SepetList(EsyaDbContext context,CartHelper cardHelp,UserManager<AppUser> userManager)
        {
            _context = context;
            _cardHelp = cardHelp;
            _userManager = userManager;

        }
        
        public IViewComponentResult Invoke()
        {
            string cartId = _cardHelp.GetOrCreateCart();

            var user = HttpContext.User;

            string? userId = user.Identity!.IsAuthenticated ? _userManager.GetUserId(user) : null;
            int totalQuantity = 0;  
            if (userId != null)
            {
                totalQuantity = _context.cartItems
                    .Where(x => x.CartID == cartId && x.UserID == Convert.ToInt32(userId))
                    .Sum(x => x.Quantity);
            }
            else
            {
                totalQuantity = _context.cartItems
                    .Where(x => x.CartID == cartId)
                    .Sum(x => x.Quantity);
            }

            return View(totalQuantity);
        }
    }
}
