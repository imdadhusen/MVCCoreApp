using HisabPro.DTO.Model;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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
            return PartialView("_Extraction");
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
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", newFileName);

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
