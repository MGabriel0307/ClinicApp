using Microsoft.AspNetCore.Identity;

namespace AgroPhytoApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? ProfileImageUrl { get; set; }
    }
}