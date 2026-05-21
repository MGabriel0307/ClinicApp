using AgroPhytoApp.Models;
using AgroPhytoApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace AgroPhytoApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly AuthService _authService;

        public AccountController(AuthService authService)
        {
            _authService = authService;
        }

        // REGISTER GET
        public IActionResult Register()
        {
            return View();
        }

        // REGISTER POST
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var result = await _authService.Register(model);

            if (result.Succeeded)
                return RedirectToAction("Login");

            foreach (var error in result.Errors)
                ModelState.AddModelError("", error.Description);

            return View(model);
        }

        // LOGIN GET
        public IActionResult Login()
        {
            return View();
        }

        // LOGIN POST
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var result = await _authService.Login(model);

            if (result.Succeeded)
                return RedirectToAction("Index", "Produse");

            ModelState.AddModelError("", "Email sau parola incorecta.");
            return View(model);
        }

        // LOGOUT
        public async Task<IActionResult> Logout()
        {
            await _authService.Logout();
            return RedirectToAction("Index", "Produse");
        }
    }
}