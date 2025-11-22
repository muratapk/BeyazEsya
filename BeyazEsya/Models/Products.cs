using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeyazEsya.Models
{
    public class Products
    {
        [Key]
        public int ProductId { get; set; }
        public string Sku { get; set; } = string.Empty;
        [ForeignKey("BrandId")]
        public int ? BrandId { get; set; }
        public Brands ? Brand { get; set; }
        [ForeignKey("CategoryId")]
        public int  ? CategoryId { get; set; } 
        public Categories ? Category { get; set; }
        public string Description { get; set; } = string.Empty; 
        public decimal ? Price { get; set; }
        public Boolean IsActive { get; set; }
        public DateTime ? Created { get; set; }
        public ICollection<ProductImages> ? ProductImages { get; set; }
    }
}
