using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

namespace AgroPhytoApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;

        public AdminController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> MakeAdmin(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
            {
                return Content("Utilizatorul nu exista.");
            }

            await _userManager.AddToRoleAsync(user, "Admin");

            return Content($"Utilizatorul {email} a fost adaugat in rolul Admin.");
        }
    }
}