using System.ComponentModel.DataAnnotations;

namespace BeyazEsya.Models
{
    public class Categories
    {
        [Key]
        public int CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int ? ParentCategoryId { get; set; }
        public  DateTime ? Created { get; set; }
        public ICollection<Products>? Products { get; set; }
    }
}
