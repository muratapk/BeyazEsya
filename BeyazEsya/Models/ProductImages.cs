using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeyazEsya.Models
{
    public class ProductImages
    {
        [Key]
        public int ImagesId { get; set; }
        [ForeignKey("ProductId")]
        public int ? ProductId { get; set; }
        public Products ? Products { get; set; }
        public string ImageUrl { get; set; }=string.Empty;
        public string ImageTitle { get; set; } = string.Empty;
        public bool IsMain { get; set; }
        public int ? OrderNo { get; set; }
        public DateTime Created { get; set; }
        [NotMapped]
        public IFormFile ? Picture { get; set; }
    }
}
