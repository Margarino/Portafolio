using OfficeOpenXml;
using financeApp.Models;
namespace financeApp
{
    public class ExcelController
    {
        public async Task exportIncome()
        {
            ModelContext contex = new ModelContext();
            var memoryStream = new MemoryStream();


            var data = contex.Ingresos.ToArray();
            ExcelPackage excel = new ExcelPackage();
            var workSheet = excel.Workbook.Worksheets.Add("ingreso");
            workSheet.Cells[1, 1].LoadFromCollection(data, true);
            excel.SaveAs(memoryStream);
            memoryStream.Position = 0;
            string filename = "test.xlsx";
            string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            //return File(memoryStream,contentType, filename);
            

        }
    }
}
