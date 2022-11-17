using crudAdmin.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace crudAdmin.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }



        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Adm model)
        {
            ModelContext modelcontext = new ModelContext();
            if (ModelState.IsValid)
            {
                var username = model.Rut;
                var password = model.Pass;

                var aux1 = modelcontext.Adms.Where(a => a.Rut == username);
                aux1 = aux1.Where(a => a.Pass == password);

                if (aux1.FirstOrDefault().Rut == username && aux1.FirstOrDefault().Pass == password)
                {
                    return RedirectToAction("Menu");
                }
            }
            return RedirectToAction("Privacy");
        }



        public IActionResult Menu()
        {
            return View();
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}