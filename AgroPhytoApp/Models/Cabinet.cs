using System.ComponentModel.DataAnnotations;

namespace AgroPhytoApp.Models
{
    public class Cabinet
    {
        public int Id { get; set; }

        [Required]
        public string Numar { get; set; }

        [Required]
        public string Specializare { get; set; }

        [Required]
        public string Dotari { get; set; }

        public string? ImagineUrl { get; set; }
    }
}