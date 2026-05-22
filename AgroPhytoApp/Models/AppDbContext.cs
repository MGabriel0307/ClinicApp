using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AgroPhytoApp.Models
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        public DbSet<Produs> Produse { get; set; }

        public DbSet<Cabinet> Cabinete { get; set; }

        public DbSet<Medic> Medici { get; set; }

        public DbSet<IstoricMedical> IstoricMedicale { get; set; }
    }
}