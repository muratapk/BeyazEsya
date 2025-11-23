using Microsoft.AspNetCore.Mvc;
using BeyazEsya.Data;
namespace BeyazEsya.Component
{
    public class KategoriList:ViewComponent
    {
        private readonly EsyaDbContext _context;
        public KategoriList(EsyaDbContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var kategoriler = _context.categories.ToList();
            return View(kategoriler);
        }
    }
}
