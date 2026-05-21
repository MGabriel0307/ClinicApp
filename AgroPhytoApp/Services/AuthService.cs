using AgroPhytoApp.Models;
using Microsoft.AspNetCore.Identity;

namespace AgroPhytoApp.Services
{
    public class AuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthService(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        // REGISTER
        public async Task<IdentityResult> Register(RegisterViewModel model)
        {
            // Creează rolurile dacă nu există
            if (!await _roleManager.RoleExistsAsync("Admin"))
            {
                await _roleManager.CreateAsync(new IdentityRole("Admin"));
            }

            if (!await _roleManager.RoleExistsAsync("Client"))
            {
                await _roleManager.CreateAsync(new IdentityRole("Client"));
            }

            // Creează utilizatorul
            var user = new ApplicationUser
            {
                UserName = Guid.NewGuid().ToString("N"),
                Email = model.Email,
                ProfileImageUrl = "https://cdn-icons-png.flaticon.com/512/149/149071.png"
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            // Adaugă rolul Client
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Client");
            }

            return result;
        }

        // LOGIN
        public async Task<SignInResult> Login(LoginViewModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                return SignInResult.Failed;
            }

            return await _signInManager.PasswordSignInAsync(
                user.UserName,
                model.Password,
                false,
                false);
        }

        // LOGOUT
        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }
    }
}