using BeyazEsya.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BeyazEsya.Component
{
    public class NewsArrived:ViewComponent
    {
        private readonly EsyaDbContext _context;
        public NewsArrived(EsyaDbContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
           // var products = _context.products.Where(p => p.IsActive).OrderByDescending(p => p.Created).Take(8).ToList();
            var products=_context.products.Include(x=>x.ProductImages).Include(x=>x.Brand).Take(8).OrderByDescending(x=>x.ProductId).ToList();
            return View(products);
        }
    }
}
