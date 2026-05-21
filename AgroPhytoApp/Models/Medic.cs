using System.ComponentModel.DataAnnotations;

namespace AgroPhytoApp.Models
{
    public class Medic
    {
        public int Id { get; set; }

        [Required]
        public string Nume { get; set; }

        [Required]
        public string Specializare { get; set; }

        [Required]
        public string Descriere { get; set; }

        public string? ImagineUrl { get; set; }

        public int Experienta { get; set; }
    }
}