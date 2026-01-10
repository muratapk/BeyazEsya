using System.ComponentModel.DataAnnotations;

namespace BeyazEsyaApi.Models
{
    public class UserLogin
    {
        [Key]
        public int Id { get; set; } 
        public string UserName { get; set; }= string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
