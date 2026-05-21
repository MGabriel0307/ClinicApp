using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AgroPhytoApp.Models;

namespace AgroPhytoApp.Controllers
{
    public class MedicController : Controller
    {
        private readonly AppDbContext _context;

        public MedicController(AppDbContext context)
        {
            _context = context;
        }

        // LISTA MEDICI
        public IActionResult Index()
        {
            var medici = _context.Medici.ToList();

            return View(medici);
        }

        // DETALII
        public IActionResult Detalii(int id)
        {
            var medic = _context.Medici.FirstOrDefault(x => x.Id == id);

            if (medic == null)
            {
                return NotFound();
            }

            return View(medic);
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
        public IActionResult Create(Medic medic)
        {
            if (!ModelState.IsValid)
            {
                return View(medic);
            }

            _context.Medici.Add(medic);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // EDIT GET
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id)
        {
            var medic = _context.Medici.FirstOrDefault(x => x.Id == id);

            if (medic == null)
            {
                return NotFound();
            }

            return View(medic);
        }

        // EDIT POST
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(Medic medic)
        {
            if (!ModelState.IsValid)
            {
                return View(medic);
            }

            _context.Medici.Update(medic);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // DELETE
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var medic = _context.Medici.FirstOrDefault(x => x.Id == id);

            if (medic != null)
            {
                _context.Medici.Remove(medic);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}