using HisabPro.Common;
using HisabPro.Constants;
using HisabPro.Constants.Resources;
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

namespace HisabPro.Web.Controllers.Private
{
    [Authorize]
    public class ImportController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly ICategoryService _categoryService;
        private readonly IExpenseService _expenseService;
        private readonly IIncomeService _incomeService;
        private readonly ISharedViewLocalizer _localizer;

        public ImportController(IAccountService accountService, ICategoryService categoryService, IExpenseService expenseService, IIncomeService incomeService, ISharedViewLocalizer localizer)
        {
            _accountService = accountService;
            _categoryService = categoryService;
            _expenseService = expenseService;
            _incomeService = incomeService;
            _localizer = localizer;
        }

        public async Task<ActionResult> Expense()
        {
            await setCatgoriesInJson(EnumCategoryType.Expense);
            return View();
        }

        public async Task<ActionResult> Income()
        {
            await setCatgoriesInJson(EnumCategoryType.Income);
            return View();
        }

        public IActionResult Upload()
        {
            return PartialView("_Upload");
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
                    response.Message = _localizer.Get(ResourceKey.LabelApiImportFileAllowedExtensions);
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
                    var path = Path.Combine(Directory.GetCurrentDirectory(), AppConst.Configs.UploadFolderPath, newFileName);

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
                response.Message = _localizer.Get(ResourceKey.LabelApiImportSuccess);
                response.Response = new { FileName = newFileName };
            }
            else
            {
                response.Message = _localizer.Get(ResourceKey.LabelApiImportFileRequired);
            }

            return StatusCode((int)response.StatusCode, response);
        }

        [HttpGet]
        public async Task<IActionResult> Extraction(string filename)
        {
            var excelService = new ExcelService();
            var folder = AppConst.Configs.UploadFolderPath;
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), folder, filename);

            var rawData = excelService.ReadExcelFile(filePath);

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

            var url = HttpContext.Request.Headers["Referer"].ToString();
            //var url = HttpContext.Request.Path.Value;
            string categoryType = StringHelper.GetActionFromUrl(url);
            var categories = await _categoryService.GetCategoriesAsync(categoryType.ToUpper() == "INCOME" ? EnumCategoryType.Income : EnumCategoryType.Expense);
            categories.Insert(0, new IdNameRes { Id = string.Empty, Name = string.Empty });
            ViewData["Categories"] = new SelectList(categories, "Id", "Name");

            return PartialView("_Extraction", listExpense);
        }

        [HttpPost]
        public async Task<IActionResult> SaveExpenses([FromBody] List<SaveExpenseReq> expenses)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            var response = await _expenseService.AddRangeAsync(expenses);
            stopwatch.Stop();

            response.Response.TotalTimeTaken = stopwatch.Elapsed.Seconds;
            return StatusCode((int)response.StatusCode, response);
        }
        [HttpPost]
        public async Task<IActionResult> SaveIncomes([FromBody] List<SaveIncomeReq> incomes)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            var response = await _incomeService.AddRangeAsync(incomes);
            stopwatch.Stop();

            response.Response.TotalTimeTaken = stopwatch.Elapsed.Seconds;
            return StatusCode((int)response.StatusCode, response);
        }

        public IActionResult Summary(int totalRecords, int totalSeconds)
        {
            return PartialView("_Summary", new SummaryModel() { Records = totalRecords, Seconds = totalSeconds });
        }

        private async Task setCatgoriesInJson(EnumCategoryType categoryType)
        {
            var categories = await _categoryService.GetCategoriesAsync(categoryType);
            ViewData["Categories"] = JsonSerializer.Serialize(categories);
            var childCategories = await _categoryService.GetSubCategoriesAsync(categoryType);
            ViewData["SubCategories"] = JsonSerializer.Serialize(childCategories);
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
