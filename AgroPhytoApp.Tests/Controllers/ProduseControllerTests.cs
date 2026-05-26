using AgroPhytoApp.Controllers;
using AgroPhytoApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace AgroPhytoApp.Tests.Controllers
{
    public class ProduseControllerTests
    {
        private AppDbContext GetDbContext()
        {
            var options =
                new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new AppDbContext(options);
        }

        [Fact]
        public void Index_Returns_View()
        {
            var context = GetDbContext();

            var controller =
                new ProduseController(context);

            var result =
                controller.Index();

            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Create_Get_Returns_View()
        {
            var context = GetDbContext();

            var controller =
                new ProduseController(context);

            var result =
                controller.Create();

            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Create_Post_Redirects()
        {
            var context = GetDbContext();

            var controller =
                new ProduseController(context);

            var produs = new Produs
            {
                Nume = "Test",
                Descriere = "Test",
                Categorie = "Test"
            };

            var result =
                controller.Create(produs);

            Assert.IsType<RedirectToActionResult>(result);
        }

        [Fact]
        public void Delete_Redirects()
        {
            var context = GetDbContext();

            var produs = new Produs
            {
                Nume = "Test",
                Descriere = "Test",
                Categorie = "Test"
            };

            context.Produse.Add(produs);

            context.SaveChanges();

            var controller =
                new ProduseController(context);

            var result =
                controller.Delete(produs.Id);

            Assert.IsType<RedirectToActionResult>(result);
        }
    }
}