using Microsoft.AspNetCore.Mvc;

namespace AgroPhytoApp.Controllers
{
    public class AuthController : Controller
    {
        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            // Extragem numele din email pentru a simula un cont real (ex: andrei@yahoo.com -> andrei)
            string numeUtilizator = email.Split('@')[0];

            // Cerința ta cere vizualizare nume ȘI email în aplicație.
            // Folosim TempData pentru a "transporta" aceste date între pagini.
            TempData["UserNume"] = numeUtilizator;
            TempData["UserEmail"] = email;

            // După login, redirecționăm către una din cele 7 pagini principale (Index)
            return RedirectToAction("Index", "Produse");
        }

        [HttpGet]
        public IActionResult Register() => View();

        // Bonus: Adăugăm și metoda de Logout pentru a reseta numele înapoi la "Vizitator"
        public IActionResult Logout()
        {
            TempData.Clear();
            return RedirectToAction("Index", "Produse");
        }
    }
}