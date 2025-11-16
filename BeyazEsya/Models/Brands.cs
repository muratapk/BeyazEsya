using System.ComponentModel.DataAnnotations;

namespace BeyazEsya.Models
{
    public class Brands
    {
        //Markalar
        [Key]
        public int BrandId { get; set; }
        [Required(ErrorMessage ="Marka Boş Geçilemez")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "Açıklama Boş Geçilemez")]
        public  string ?  Description { get; set; }
        public DateTime ? CreateAt { get; set; }

    }
}
