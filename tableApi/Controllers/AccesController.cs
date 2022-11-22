using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using tableApi.Models;


namespace tableApi.Controllers
{
    public class AccessController : Controller
    {
        public IActionResult Login()
        {
            ClaimsPrincipal claimUser = HttpContext.User;

            if (claimUser.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");


            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Mesa modelLogin, string supervisor, string password)
        {
            bool lst;
            using (ModelContext context = new ModelContext())
            {
                lst = context.Mesas.Any(x=> x.Supervisor == supervisor && x.Password == password);

                if (lst)
                {

                    modelLogin.Supervisor = supervisor;

                    List<Claim> claims = new List<Claim>() {
                            new Claim(ClaimTypes.NameIdentifier, modelLogin.Supervisor),
                            new Claim("OtherProperties","Example Role")

                    };



                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims,
                        CookieAuthenticationDefaults.AuthenticationScheme);

                    AuthenticationProperties properties = new AuthenticationProperties()
                    {

                        AllowRefresh = true,
                        IsPersistent = modelLogin.Keeploggedin
                    };

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity), properties);

                    return RedirectToAction("Index","Home");
                }
                else
                {
                    ViewData["ValidateMessage"] = "user not found";
                    return View();
                }

            }

        }
    }
}