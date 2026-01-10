using Microsoft.EntityFrameworkCore;
using BeyazEsyaApi.Models;
namespace BeyazEsyaApi.Data
{
    public class BeyazEsyaDb:DbContext
    {
        public BeyazEsyaDb(DbContextOptions<BeyazEsyaDb>options):base(options)
        {
        
        }   
        public DbSet<Brands> Brands { get; set; }   
    }
}
