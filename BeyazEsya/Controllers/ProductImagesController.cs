using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BeyazEsya.Data;
using BeyazEsya.Models;

namespace BeyazEsya.Controllers
{
    public class ProductImagesController : Controller
    {
        private readonly EsyaDbContext _context;

        public ProductImagesController(EsyaDbContext context)
        {
            _context = context;
        }

        // GET: ProductImages
        public async Task<IActionResult> Index()
        {
            var esyaDbContext = _context.productImages.Include(p => p.Products);
            return View(await esyaDbContext.ToListAsync());
        }

        // GET: ProductImages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productImages = await _context.productImages
                .Include(p => p.Products)
                .FirstOrDefaultAsync(m => m.ImagesId == id);
            if (productImages == null)
            {
                return NotFound();
            }

            return View(productImages);
        }

        // GET: ProductImages/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.products, "ProductId", "Sku");
            return View();
        }

        // POST: ProductImages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ImagesId,ProductId,ImageUrl,ImageTitle,IsMain,OrderNo,Created")] ProductImages productImages,IFormFile picture)
        {
            var uzanti=Path.GetExtension(picture.FileName);
            //dosya adının uzantısı alındı
            if(uzanti.ToLower()!=".jpg" && uzanti.ToLower()!=".png" && uzanti.ToLower()!=".jpeg" && uzanti.ToLower()!=".gif")
            {
                ModelState.AddModelError("Picture","Yüklenen dosya jpg,gif,png veya jpeg formatında olmalıdır.");
                ViewData["ProductId"] = new SelectList(_context.products, "ProductId", "Sku", productImages.ProductId);
                return View(productImages);
            }

            var yeniDosyaAdi=Guid.NewGuid()+uzanti.ToLower();
            var filePath=Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/Product_Images/",yeniDosyaAdi);
            using(var stream=new FileStream(filePath,FileMode.Create))
            {
                await picture.CopyToAsync(stream);
                productImages.ImageUrl="/Product_Images/"+yeniDosyaAdi;
            }

            if (ModelState.IsValid)
            {
                _context.Add(productImages);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.products, "ProductId", "Sku", productImages.ProductId);
            return View(productImages);
        }

        // GET: ProductImages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productImages = await _context.productImages.FindAsync(id);
            if (productImages == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.products, "ProductId", "Sku", productImages.ProductId);
            return View(productImages);
        }

        // POST: ProductImages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ImagesId,ProductId,ImageUrl,ImageTitle,IsMain,OrderNo,Created")] ProductImages productImages,IFormFile picture)
        {

            var uzanti = Path.GetExtension(picture.FileName);
            //dosya adının uzantısı alındı
            if (uzanti.ToLower() != ".jpg" && uzanti.ToLower() != ".png" && uzanti.ToLower() != ".jpeg" && uzanti.ToLower() != ".gif")
            {
                ModelState.AddModelError("Picture", "Yüklenen dosya jpg,gif,png veya jpeg formatında olmalıdır.");
                ViewData["ProductId"] = new SelectList(_context.products, "ProductId", "Sku", productImages.ProductId);
                return View(productImages);
            }

            var yeniDosyaAdi = Guid.NewGuid() + uzanti.ToLower();
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Product_Images/", yeniDosyaAdi);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await picture.CopyToAsync(stream);
                productImages.ImageUrl = "/Product_Images/" + yeniDosyaAdi;
            }




            if (id != productImages.ImagesId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productImages);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductImagesExists(productImages.ImagesId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.products, "ProductId", "Sku", productImages.ProductId);
            return View(productImages);
        }

        // GET: ProductImages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productImages = await _context.productImages
                .Include(p => p.Products)
                .FirstOrDefaultAsync(m => m.ImagesId == id);
            if (productImages == null)
            {
                return NotFound();
            }

            return View(productImages);
        }

        // POST: ProductImages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productImages = await _context.productImages.FindAsync(id);
            if (productImages != null)
            {
                _context.productImages.Remove(productImages);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductImagesExists(int id)
        {
            return _context.productImages.Any(e => e.ImagesId == id);
        }
    }
}
