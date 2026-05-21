using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace AgroPhytoApp.Models
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Produs> Produse { get; set; }

        public DbSet<Categorie> Categorii { get; set; }

        public DbSet<Comanda> Comenzi { get; set; }

        public DbSet<Furnizor> Furnizori { get; set; }

        public DbSet<Recenzie> Recenzii { get; set; }

        // MEDICI
        public DbSet<Medic> Medici { get; set; }
    }
}