using System.ComponentModel.DataAnnotations;

namespace AgroPhytoApp.Models
{
    public class IstoricMedical
    {
        public int Id { get; set; }

        [Required]
        public string NumePacient { get; set; }

        [Required]
        public string Diagnostic { get; set; }

        [Required]
        public string Reteta { get; set; }

        public string? Observatii { get; set; }

        public string? DataConsultatie { get; set; }
    }
}