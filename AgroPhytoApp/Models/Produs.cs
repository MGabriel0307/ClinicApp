using System;
using System.ComponentModel.DataAnnotations;

namespace AgroPhytoApp.Models
{
    public class Produs
    {
        public int Id { get; set; }

        [Required]
        public string Nume { get; set; }

        [Required]
        public string Descriere { get; set; }

        // FORMULA PROFESORULUI

        [Required]
        public double TaxaConsultatie { get; set; }

        [Required]
        public int NrAnalize { get; set; }

        public double Pret
        {
            get
            {
                return TaxaConsultatie + (NrAnalize * 75);
            }
        }

        [Required]
        public string Categorie { get; set; }

        public string? ImagineUrl { get; set; }

        // PACIENT

        public string? Telefon { get; set; }

        public string? CNP { get; set; }

        public string? Adresa { get; set; }

        // PROGRAMARE

        public DateTime? DataProgramare { get; set; }

        public string? OraProgramare { get; set; }

        // STATUS

        public string? StatusProgramare { get; set; }
    }
}