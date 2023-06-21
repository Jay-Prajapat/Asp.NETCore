using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Practical17.Interface;
using Practical17.Models;
using System.Security.Claims;

namespace Practical17.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUser _users;
        private readonly IStudent _students;

        public List<User> users;


        public AccountController(IUser user) {

            _users = user;
            users = _users.GetAllUsers();

        }
        public IActionResult Login(string returnUrl = "/")
        {
            LoginModel loginModel = new LoginModel();
            loginModel.ReturnUrl = returnUrl;
            return View(loginModel);
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)     
        {
            if (ModelState.IsValid)
            {
                var user = users.FirstOrDefault(u => u.FirstName == model.UserName && u.Password == model.Password);
                if (user != null)
                {


                    var Claim = new List<Claim>()
                    {
                        new Claim(ClaimTypes.NameIdentifier,Convert.ToString(user.UserId)),
                        new Claim(ClaimTypes.Name,user.FirstName),
                        new Claim(ClaimTypes.Role,user.Roles.RoleName),
                        new Claim("RoleBased","Code")
                    };

                    var identity = new ClaimsIdentity(Claim, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal,
                        new AuthenticationProperties()
                        {
                            IsPersistent = model.RememberMe
                        });
                    return LocalRedirect(model.ReturnUrl);
                }
                else
                {
                    ViewBag.Message = "Invalid Cradential";
                    return View(model);
                }
            }
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return LocalRedirect("/");
        }
        
    }
}
