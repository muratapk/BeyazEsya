using System.ComponentModel.DataAnnotations;

namespace BeyazEsya.Models
{
    public class Customers
    {
        [Key]
        public int CustomerId { get; set; }

        [Required]
        [MaxLength(255)]
        public string Email { get; set; } = String.Empty;

        [Required]
        [MaxLength(255)]
        public string ? PasswordHash { get; set; }

        [MaxLength(100)]
        public string ? FirstName { get; set; }

        [MaxLength(100)]
        public string ? LastName { get; set; }

        [MaxLength(50)]
        public string ? Phone { get; set; }

        public DateTime ? CreatedAt { get; set; } = DateTime.UtcNow;

        public bool ? IsActive { get; set; } = true;
    }
}
