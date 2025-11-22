using BeyazEsya.Data;
using Microsoft.AspNetCore.Mvc;

namespace BeyazEsya.Component
{
    public class TrendlList:ViewComponent
    {
        private readonly EsyaDbContext _context;
        public TrendlList(EsyaDbContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
           // var products = _context.products.Where(p => p.IsActive).OrderByDescending(p => p.Created).Take(8).ToList();
            var products=_context.products.Take(8).ToList();
            return View(products);
        }
    }
}
