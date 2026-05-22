using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AgroPhytoApp.Models;

namespace AgroPhytoApp.Controllers
{
    public class CabinetController : Controller
    {
        private readonly AppDbContext _context;

        public CabinetController(AppDbContext context)
        {
            _context = context;
        }

        // LISTA CABINETE
        public IActionResult Index()
        {
            var cabinete = _context.Cabinete.ToList();

            return View(cabinete);
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
        public IActionResult Create(Cabinet cabinet)
        {
            if (ModelState.IsValid)
            {
                _context.Cabinete.Add(cabinet);

                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(cabinet);
        }

        // EDIT GET
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id)
        {
            var cabinet = _context.Cabinete.Find(id);

            return View(cabinet);
        }

        // EDIT POST
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(Cabinet cabinet)
        {
            if (ModelState.IsValid)
            {
                _context.Cabinete.Update(cabinet);

                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(cabinet);
        }

        // DELETE
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var cabinet = _context.Cabinete.Find(id);

            _context.Cabinete.Remove(cabinet);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}