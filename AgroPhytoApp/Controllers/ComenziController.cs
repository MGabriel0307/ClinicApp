using Microsoft.AspNetCore.Mvc;

namespace AgroPhytoApp.Controllers
{
    public class ComenziController : Controller
    {
        // Aceasta metoda deschide Pagina 4: Coșul de cumpărături
        public IActionResult Cos()
        {
            return View();
        }

        // Aceasta metoda deschide Pagina 5: Istoricul comenzilor
        public IActionResult Istoric()
        {
            return View();
        }
    }
}