using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using clientwebapp.Models;


namespace AuthProject.Controllers
{
    public class AccessController : Controller
    {
        public IActionResult Login()
        {
            ClaimsPrincipal claimUser = HttpContext.User;

            if (claimUser.Identity.IsAuthenticated)
            {
                
            }
                return RedirectToAction("Index", "Home");


            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Empleado2 modelLogin, string DescripcionCargo, string Rut)
        {
            bool lst;
            using (ModelContext context = new ModelContext())
            {
                lst = context.Empleado2s.Any(x => x.DescripcionCargo == DescripcionCargo && x.Rut == Rut);

                if (lst)
                {

                    modelLogin.DescripcionCargo = DescripcionCargo;

                    List<Claim> claims = new List<Claim>() {
                            new Claim(ClaimTypes.NameIdentifier, modelLogin.DescripcionCargo),
                            new Claim("OtherProperties","Example Role")

                    };

                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims,
                    CookieAuthenticationDefaults.AuthenticationScheme);

                    AuthenticationProperties properties = new AuthenticationProperties()
                    {

                        AllowRefresh = true,
                        IsPersistent = modelLogin.KeepLoggedIn
                    };

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity), properties);

                    return RedirectToAction("Index", "Home");


                }
                ViewData["ValidateMessage"] = "user not found";
                return View();

            }

        }
    }
}
