using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AgroPhytoApp.Models;

namespace AgroPhytoApp.Controllers
{
    public class IstoricMedicalController : Controller
    {
        private readonly AppDbContext _context;

        public IstoricMedicalController(AppDbContext context)
        {
            _context = context;
        }

        // LISTA ISTORIC
        public IActionResult Index()
        {
            var istoric = _context.IstoricMedicale.ToList();

            return View(istoric);
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
        public IActionResult Create(IstoricMedical istoricMedical)
        {
            if (ModelState.IsValid)
            {
                _context.IstoricMedicale.Add(istoricMedical);

                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(istoricMedical);
        }

        // EDIT GET
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id)
        {
            var istoric = _context.IstoricMedicale.Find(id);

            return View(istoric);
        }

        // EDIT POST
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(IstoricMedical istoricMedical)
        {
            if (ModelState.IsValid)
            {
                _context.IstoricMedicale.Update(istoricMedical);

                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(istoricMedical);
        }

        // DELETE
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var istoric = _context.IstoricMedicale.Find(id);

            _context.IstoricMedicale.Remove(istoric);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}