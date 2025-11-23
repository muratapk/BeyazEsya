using BeyazEsya.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BeyazEsya.Component
{
    public class SliderList:ViewComponent
    {
        private readonly EsyaDbContext _context;

        public SliderList(EsyaDbContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            
            var products = _context.products.Include(x => x.ProductImages).Include(x => x.Brand).Take(8).ToList();
            return View(products);
        }

    }
}
