using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AgroPhytoApp.Services;
using AgroPhytoApp.Models;
using System.Linq;

namespace AgroPhytoApp.Controllers
{
    public class ProduseController : Controller
    {
        private readonly ProdusService _service;

        public ProduseController(ProdusService service)
        {
            _service = service;
        }

        // HOME
        public IActionResult Index()
        {
            return View();
        }

        // PROGRAMARI
        public IActionResult Catalog()
        {
            var produse = _service.GetAllProduse();

            return View(produse);
        }

        // FILTRARE
        public IActionResult Categorie(string tip)
        {
            var produse = _service.GetAllProduse();

            var produseFiltrate = produse
                .Where(p => p.Categorie == tip)
                .ToList();

            return View("Catalog", produseFiltrate);
        }

        // DETALII
        public IActionResult Detalii(int id)
        {
            var produs = _service.GetProdusById(id);

            if (produs == null)
            {
                return NotFound();
            }

            return View(produs);
        }

        // MEDICI
        public IActionResult DespreNoi()
        {
            return View();
        }

        // CABINETE
        public IActionResult Contact()
        {
            return View();
        }

        // RETETE
        public IActionResult Retete()
        {
            return View();
        }

        // ECHIPAMENTE
        public IActionResult Echipamente()
        {
            return View();
        }

        // PROGRAMARE CONSULTATIE
        public IActionResult Cos(string numeProdus)
        {
            ViewBag.ProdusSelectat = numeProdus;

            return View();
        }

        // ISTORIC
        public IActionResult Istoric(string numeProdus)
        {
            ViewBag.ProdusCumparat = numeProdus;

            return View();
        }

        // TEST
        public IActionResult Test()
        {
            var produse = _service.GetAllProduse();

            return Content("Programări: " + produse.Count);
        }

        // TEST CREATE
        public IActionResult AddTest()
        {
            var produs = new Produs
            {
                Nume = "Ion Popescu",
                Descriere = "Consultație cardiologie",
                Pret = 250,
                Categorie = "Cardiologie",
                ImagineUrl = "https://images.unsplash.com/photo-1584982751601-97dcc096659c?w=800",
                Telefon = "0722222222",
                CNP = "1234567890123",
                Adresa = "Craiova",
                DataProgramare = DateTime.Now,
                OraProgramare = "10:00"
            };

            _service.AddProdus(produs);

            return Content("Programare adăugată!");
        }

        // CREATE GET
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // CREATE POST
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Create(Produs produs)
        {
            try
            {
                _service.AddProdus(produs);

                return RedirectToAction("Catalog");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        // DELETE
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            _service.DeleteProdus(id);

            return RedirectToAction("Catalog");
        }

        // EDIT GET
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id)
        {
            var produs = _service.GetProdusById(id);

            return View(produs);
        }

        // EDIT POST
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(Produs produs)
        {
            try
            {
                _service.UpdateProdus(produs);

                return RedirectToAction("Catalog");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
    }
}