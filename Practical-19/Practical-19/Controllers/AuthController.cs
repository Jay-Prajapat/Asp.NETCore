using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Practical_19.Interface;
using Practical_19.Models;

namespace Practical_19.Controllers
{
    public class AuthController : Controller
    {
        string successMessage = "Registration completed successfully!!";
        string errorMessage = "Something went wrong!!!";
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly IAuthentication authentication;
        public AuthController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IAuthentication authentication)
        {

            this.userManager = userManager;
            this.signInManager = signInManager;
            this.authentication = authentication;
        }

        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityResult result = await authentication.RegisterUserAsync(model);

                if (result.Succeeded)
                {
                    return RedirectToAction("Login");
                }
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View();

        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await authentication.LoginUserAsync(model);
                if (result != null)
                {

                    var user = await userManager.FindByEmailAsync(model.Email);
                    var roles = await userManager.GetRolesAsync(user);
                    if (roles.Contains("Admin"))
                    {
                        return RedirectToAction("ListRoles", "Administration");
                    }
                    else if (roles.Contains("User"))
                    {
                        return RedirectToAction("Dashboard", "User");
                    }

                }
                else
                {
                    return RedirectToPage("Index");
                }
            }
            ModelState.AddModelError("", "Email or Password Incorrect");
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

    }
   
}

