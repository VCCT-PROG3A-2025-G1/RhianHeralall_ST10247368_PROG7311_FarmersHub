using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using FarmersHub.Models;
using FarmersHub.ViewModels;
using System.Threading.Tasks;

namespace FarmersHub.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<FarmersHub.Models.ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)

        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
            if (result.Succeeded)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                var roles = await _userManager.GetRolesAsync(user);
                if (roles.Contains("Employee"))
                    return RedirectToAction("Index", "Farmers");
                else
                    return RedirectToAction("MyProducts", "Products");
            }

            ModelState.AddModelError("", "Invalid login attempt.");
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }

    }
}
