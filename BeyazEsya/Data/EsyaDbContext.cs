using BeyazEsya.Models;
using Microsoft.EntityFrameworkCore;

namespace BeyazEsya.Data
{
    public class EsyaDbContext:DbContext
    {
        //Constructor
        public EsyaDbContext(DbContextOptions<EsyaDbContext>options):base(options)
        {

        }
        public DbSet<Brands>? brands { get; set; }
        public DbSet<Customers> ? customers { get; set; }
        public DbSet<Categories>? categories { get; set; }
        public DbSet<Products>? products { get; set; }
        public DbSet<ProductImages>? productImages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
             modelBuilder.Entity<Products>().
                HasOne(p => p.Brand).
                WithMany(b => b.Products).
                HasForeignKey(p => p.BrandId);

             modelBuilder.Entity<Products>().
                HasOne(p => p.Category).
                WithMany(c => c.Products).
                HasForeignKey(p => p.CategoryId);

            modelBuilder.Entity<ProductImages>().
                HasOne(pi => pi.Products).
                WithMany(p => p.ProductImages).
                HasForeignKey(pi => pi.ProductId);

        }
    }
}
