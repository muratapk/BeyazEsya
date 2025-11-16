using BeyazEsya.Data;
using BeyazEsya.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace BeyazEsya.Controllers
{
    public class BrandsController : Controller
    {
        private readonly EsyaDbContext _context;
        public BrandsController(EsyaDbContext context) 
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var result=_context.brands.ToList();
            return View(result);
        }
        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Brands gelen)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            gelen.CreateAt = DateTime.Now;
            _context.brands.Add(gelen);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (id == null)
            {
                return NotFound();

            }
            var result = _context.brands.Where(x => x.BrandId == id).FirstOrDefault();
            if (result != null)
            {
                return View(result);
            }
            return View();
        }
        [HttpPost]
        public IActionResult Edit(Brands gelen)
        {
            // var result = _context.brands.Where(x => x.BrandId == id).FirstOrDefault();
            if (!ModelState.IsValid)
            {
                return View();
            }
            gelen.CreateAt = DateTime.Now;
            _context.brands.Update(gelen);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var result = _context.brands.Where(x => x.BrandId == id).FirstOrDefault();
            if(result!=null)
            {
                _context.brands.Remove(result);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
