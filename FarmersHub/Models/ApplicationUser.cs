using Microsoft.AspNetCore.Identity;

namespace FarmersHub.Models
{
   
    public class ApplicationUser : IdentityUser
    {
        public string Role { get; set; }
        
    }
}
