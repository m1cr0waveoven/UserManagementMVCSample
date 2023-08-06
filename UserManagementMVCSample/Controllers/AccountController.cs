using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using UserManagementMVCSample.Core.DataAccess;
using UserManagementMVCSample.Models;

namespace UserManagementMVCSample.Controllers
{
    public class AccountController : Controller
    {
        readonly IDataAccess _dataAccess;
        public AccountController(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            // Validate the model
            if (ModelState.IsValid)
            {
                var person = (await _dataAccess.GetPeople()).FirstOrDefault(p => p.Username == model.UserName && p.Password == model.Password);

                if (person == default && person?.ID <= 0)
                {
                    ModelState.AddModelError("", "Invalid username or password");                    
                }

                var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, model.UserName)
                    };

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties();

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                return RedirectToAction("People", "Person");


            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
