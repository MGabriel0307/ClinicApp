using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AgroPhytoApp.Models;

namespace AgroPhytoApp.Controllers
{
    public class ProduseController : Controller
    {
        private readonly AppDbContext _context;

        public ProduseController(AppDbContext context)
        {
            _context = context;
        }

        // LISTA
        public IActionResult Index()
        {
            var produse = _context.Produse.ToList();

            return View(produse);
        }

        // DETAILS
        public IActionResult Details(int id)
        {
            var produs = _context.Produse.Find(id);

            return View(produs);
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
            if (ModelState.IsValid)
            {
                _context.Produse.Add(produs);

                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(produs);
        }

        // EDIT GET
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id)
        {
            var produs = _context.Produse.Find(id);

            return View(produs);
        }

        // EDIT POST
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(Produs produs)
        {
            if (ModelState.IsValid)
            {
                _context.Produse.Update(produs);

                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(produs);
        }

        // DELETE
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var produs = _context.Produse.Find(id);

            _context.Produse.Remove(produs);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // DASHBOARD
        public IActionResult Dashboard()
        {
            var produse = _context.Produse.ToList();

            ViewBag.TotalProgramari = produse.Count;

            ViewBag.TotalPacienti = produse.Count;

            ViewBag.ProgramariConfirmate =
                produse.Count(p => p.StatusProgramare == "Confirmata");

            // FORMULA PROFULUI

            ViewBag.VenitTotal =
                produse.Sum(p => p.TaxaConsultatie + (p.NrAnalize * 75));

            return View();
        }
    }
}