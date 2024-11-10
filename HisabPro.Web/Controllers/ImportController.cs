using HisabPro.DTO.Model;
using HisabPro.Web.Helper;
using HisabPro.Web.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using static HisabPro.Constants.AppConst;

namespace HisabPro.Web.Controllers
{
    public class ImportController : Controller
    {
        public ActionResult Expense()
        {
            return View();
        }

        public ActionResult Income()
        {
            return View();
        }

        public IActionResult Upload()
        {
            return PartialView("_Upload");
        }

        [HttpGet]
        public IActionResult Extraction(string filename)
        {
            var excelService = new ExcelService();
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), Configs.UploadFolderPath, filename);

            var rawData = excelService.ReadExcelFile(filePath);
            try
            {
                var listExpense = rawData.Select(data => new ImportDataModel
                {
                    Date = data[0],               // Map string[] element to Date
                    Description = data[1],        // Map string[] element to Description
                    Amount = int.TryParse(data[2], out int amount) ? amount : 0, // Safely parse Amount
                    Category = data[3],           // Map string[] element to Category
                    SubCategory = data[4],        // Map string[] element to SubCategory
                    Person = data[5]              // Map string[] element to Person
                }).ToList();

                return PartialView("_Extraction", listExpense);
            }
            catch(Exception ex)
            {

            }
            return PartialView("_Extraction", new List<ImportDataModel>());
        }

        public IActionResult Validation()
        {
            return PartialView("_Validation");
        }

        public IActionResult Submit()
        {
            return PartialView("_Submit");
        }

        public async Task<IActionResult> SaveFile(IFormFile file)
        {
            var response = new ResponseDTO<object>();
            response.StatusCode = HttpStatusCode.BadRequest;

            if (file != null && file.Length > 0)
            {
                // Validate file extension
                var extension = Path.GetExtension(file.FileName).ToLower();
                if (extension != ".xls" && extension != ".xlsx")
                {
                    response.Message = "Only .xls and .xlsx files are allowed!";
                }

                // Extract original file name and extension
                var originalFileName = Path.GetFileNameWithoutExtension(file.FileName);
                var fileExtension = Path.GetExtension(file.FileName);
                // Generate a unique name with a timestamp
                var timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
                var newFileName = $"{originalFileName}-{timestamp}{fileExtension}";

                try
                {
                    // Define the path to save the uploaded file
                    var path = Path.Combine(Directory.GetCurrentDirectory(), Configs.UploadFolderPath, newFileName);

                    // Save the file to the specified path
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }
                catch (Exception)
                {

                    throw;
                }

                response.StatusCode = HttpStatusCode.OK;
                response.Message = "File uploaded successfully!";
                response.Response = new { FileName = newFileName };
            }
            else
            {
                response.Message = "Please select a file to upload.";
            }

            return StatusCode((int)response.StatusCode, response);
        }
    }
}
