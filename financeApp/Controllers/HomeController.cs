using financeApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


using OfficeOpenXml;
using financeApp.Models;



namespace financeApp.Controllers
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

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Menu()
        {
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


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

        public IActionResult income()
        {
            ModelContext contex = new ModelContext();
            var memoryStream = new MemoryStream();


            var data = contex.Ingresos.ToArray();

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial; //you greedy fucks

            ExcelPackage excel = new ExcelPackage();
            var workSheet = excel.Workbook.Worksheets.Add("ingreso");
            workSheet.Cells[1, 1].LoadFromCollection(data, true);
            excel.SaveAs(memoryStream);
            memoryStream.Position = 0;
            string filename = "test.xlsx";
            string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            return File(memoryStream, contentType, filename);

        }
        public IActionResult outcome()
        {
            ModelContext contex = new ModelContext();
            var memoryStream = new MemoryStream();


            var data = contex.Egresos.ToArray();

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial; //i aint paying shit for what it used to be free. 

            ExcelPackage excel = new ExcelPackage();
            var workSheet = excel.Workbook.Worksheets.Add("Egreso");
            workSheet.Cells[1, 1].LoadFromCollection(data, true);
            excel.SaveAs(memoryStream);
            memoryStream.Position = 0;
            string filename = "test.xlsx";
            string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            return File(memoryStream, contentType, filename);

        }
















    }
}