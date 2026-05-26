using AgroPhytoApp.Models;
using Xunit;

namespace AgroPhytoApp.Tests.Models
{
    public class ProdusTests
    {
        [Fact]
        public void Produs_Has_Name()
        {
            var produs = new Produs
            {
                Nume = "Laptop"
            };

            Assert.Equal(
                "Laptop",
                produs.Nume);
        }

        [Fact]
        public void Produs_Has_Description()
        {
            var produs = new Produs
            {
                Descriere = "Descriere test"
            };

            Assert.Equal(
                "Descriere test",
                produs.Descriere);
        }

        [Fact]
        public void Produs_Has_Category()
        {
            var produs = new Produs
            {
                Categorie = "Electronice"
            };

            Assert.Equal(
                "Electronice",
                produs.Categorie);
        }

        [Fact]
        public void Produs_Has_Image()
        {
            var produs = new Produs
            {
                ImagineUrl = "test.jpg"
            };

            Assert.Equal(
                "test.jpg",
                produs.ImagineUrl);
        }

        [Fact]
        public void Produs_Phone_Not_Null()
        {
            var produs = new Produs
            {
                Telefon = "0711111111"
            };

            Assert.NotNull(produs.Telefon);
        }

        [Fact]
        public void Produs_Address_Not_Null()
        {
            var produs = new Produs
            {
                Adresa = "Craiova"
            };

            Assert.NotNull(produs.Adresa);
        }

        [Fact]
        public void Produs_CNP_Length()
        {
            var produs = new Produs
            {
                CNP = "1234567890123"
            };

            Assert.Equal(
                13,
                produs.CNP.Length);
        }

        [Fact]
        public void Produs_Status_Test()
        {
            var produs = new Produs
            {
                StatusProgramare = "Confirmata"
            };

            Assert.Equal(
                "Confirmata",
                produs.StatusProgramare);
        }

        [Fact]
        public void Produs_Programare_Not_Null()
        {
            var produs = new Produs
            {
                OraProgramare = "12:00"
            };

            Assert.NotNull(
                produs.OraProgramare);
        }

        [Fact]
        public void Produs_Date_Test()
        {
            var produs = new Produs
            {
                DataProgramare = DateTime.Now
            };

            Assert.True(
                produs.DataProgramare.HasValue);
        }
    }
}