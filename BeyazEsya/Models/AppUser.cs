using Microsoft.AspNetCore.Identity;

namespace BeyazEsya.Models
{
    public class AppUser:IdentityUser<int>
    {
        public string  FirstName { get; set; }=string.Empty;
        public string ? LastName { get; set; }
        public string City { get; set; }=string.Empty;  
        public int ? ConfirmCode { get; set; }    
    }
}
