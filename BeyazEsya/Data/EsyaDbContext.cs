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
        public DbSet<Brands> brands { get; set; }
        public DbSet<Customers>customers { get; set; }
    }
}
