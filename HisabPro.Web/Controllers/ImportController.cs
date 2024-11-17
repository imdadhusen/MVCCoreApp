using HisabPro.DTO.Model;
using HisabPro.DTO.Request;
using HisabPro.DTO.Response;
using HisabPro.Services.Implements;
using HisabPro.Services.Interfaces;
using HisabPro.Web.Helper;
using HisabPro.Web.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using System.Net;
using System.Text.Json;
using static HisabPro.Constants.AppConst;

namespace HisabPro.Web.Controllers
{
    [Authorize]
    public class ImportController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly ICategoryService _categoryService;
        private readonly IExpenseService _expenseService;

        public ImportController(IAccountService accountService, ICategoryService categoryService, IExpenseService expenseService)
        {
            _accountService = accountService;
            _categoryService = categoryService;
            _expenseService = expenseService;
        }

        public async Task<ActionResult> Expense()
        {
            var childCategories = await _categoryService.GetChildCategoriesAsync();
            ViewData["ChildCategories"] = JsonSerializer.Serialize(childCategories);
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

        public IActionResult Summary(int totalRecords, int totalSeconds)
        {
            return PartialView("_Summary", new SummaryModel() { Records = totalRecords, Seconds = totalSeconds });
        }

        [HttpGet]
        public async Task<IActionResult> Extraction(string filename)
        {
            var excelService = new ExcelService();
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), Configs.UploadFolderPath, filename);

            var rawData = excelService.ReadExcelFile(filePath);
            try
            {
                var listExpense = rawData.Select(data => new ImportDataModel
                {
                    Date = getDateTime(data[0]),
                    Description = data[1],
                    Amount = int.TryParse(data[2], out int amount) ? amount : 0,
                    Category = data[3],
                    SubCategory = data[4],
                    Person = data[5]
                }).ToList();

                var accounts = await _accountService.GetAccountsAsync();
                accounts.Insert(0, new IdNameRes { Id = string.Empty, Name = string.Empty });
                ViewData["Accounts"] = new SelectList(accounts, "Id", "Name");

                var categories = await _categoryService.GetParentCategoriesAsync();
                categories.Insert(0, new IdNameRes { Id = string.Empty, Name = string.Empty });
                ViewData["Categories"] = new SelectList(categories, "Id", "Name");

                return PartialView("_Extraction", listExpense);
            }
            catch (Exception ex)
            {

            }
            return PartialView("_Extraction", new List<ImportDataModel>());
        }

        [HttpPost]
        public async Task<IActionResult> SaveTableData([FromBody] List<SaveExpense> saveDataModels)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            var response = await _expenseService.AddRangeAsync(saveDataModels);
            stopwatch.Stop();

            response.Response.TotalTimeTaken = stopwatch.Elapsed.Seconds;
            return StatusCode((int)response.StatusCode, response);
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

        private DateTime? getDateTime(string rawDate)
        {
            // Assign value
            if (string.IsNullOrWhiteSpace(rawDate))
            {
                return null; // Set null if the input is empty
            }
            else
            {
                // Try parsing the date and assign it
                if (DateTime.TryParse(rawDate, out DateTime parsedDate))
                {
                    return parsedDate.Date; // Set only the date part (time is discarded)
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
