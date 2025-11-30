using BeyazEsya.Data;
using BeyazEsya.Models;

namespace BeyazEsya.Services
{
    public class CartService
    {
        private readonly EsyaDbContext _context;
        private readonly CartHelper _cardHelp;

        public CartService(EsyaDbContext context, CartHelper cardHelp)
        {
            _context = context;
            _cardHelp = cardHelp;
        }
        public async Task AddCart(int ProductId,int Quantity)
        {
            var cardId = _cardHelp.GetOrCreateCart();
            var item = _context.cartItems.FirstOrDefault(x=>x.CartID==cardId && x.ProductID==ProductId);
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
                item.Quantity = Quantity;
            }
            await _context.SaveChangesAsync();
        }
    }
}
