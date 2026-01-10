using System.ComponentModel.DataAnnotations;

namespace BeyazEsyaApi.Models
{
    public class Brands
    {
        [Key]
        public int BrandId { get; set; }
        [Required(ErrorMessage = "Marka Boş Geçilemez")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "Açıklama Boş Geçilemez")]
        public string? Description { get; set; }
    }
}
