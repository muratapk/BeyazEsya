using BeyazEsya.Data;
using BeyazEsya.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace BeyazEsya.Controllers
{
    public class SepetController : Controller
    {
        private readonly EsyaDbContext _context;
        private readonly CartHelper _cardHelp;
        private readonly UserManager<AppUser> _userManager;

        public SepetController(EsyaDbContext context, CartHelper cardHelp,UserManager<AppUser> userManager)
        {
            _context = context;
            _cardHelp = cardHelp;
            _userManager = userManager;
        }

        public async  Task<IActionResult> Add(int id, int Quantity=1)
        {
            int ProductId = id;
            string? userId = User.Identity!.IsAuthenticated ? _userManager.GetUserId(User) : null;
            string cartId = _cardHelp.GetOrCreateCart();
            var item = _context.cartItems.FirstOrDefault(x => x.CartID == cartId && x.ProductID == ProductId);
            if (item == null)
            {
                item = new CartItem
                {
                    ProductID = ProductId,
                    Quantity = Quantity,
                    CartID = cartId,
                    UserID = Convert.ToInt32(userId)
                };
                _context.cartItems.Add(item);

            }
            else
            {
                item.Quantity += Quantity;
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("Index","Home");
        }


        public async Task<IActionResult>BasketList()
        {
            string cartId = _cardHelp.GetOrCreateCart();
            string? userId = User.Identity!.IsAuthenticated ? _userManager.GetUserId(User) : null;

            List<CartItem> items;
            if(userId!=null)
            {
                items = await _context.cartItems.Where(x => x.UserID == Convert.ToInt32(userId)).ToListAsync();

            }
            else
            {
                items=await _context.cartItems.Where(x=>x.CartID == cartId).ToListAsync();    
            }
                return View(items);
        }

        public async Task<IActionResult>AddCart(int id, int Quantity=1)
        {
            int ProductId = id;
            var cardId = _cardHelp.GetOrCreateCart();
            var item = _context.cartItems.FirstOrDefault(x => x.CartID == cardId && x.ProductID == ProductId);
            if (item == null)
            {
                item = new CartItem
                {
                    CartID = cardId,
                    ProductID = ProductId,
                    Quantity = Quantity
                };
                await _context.SaveChangesAsync();
            }
            else
            {
                item.Quantity += Quantity;
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
