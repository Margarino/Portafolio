using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Enter(string idmesa)
        {
            try
            {
                return Content("");
            }
            catch (Exception ex)
            {
                return Content("Ocurrio un error" + ex.Message);
            }
        }
    }
}
