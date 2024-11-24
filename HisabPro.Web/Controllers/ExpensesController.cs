using HisabPro.DTO.Request;
using HisabPro.DTO.Response;
using HisabPro.Services.Implements;
using HisabPro.Services.Interfaces;
using HisabPro.Web.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Json;
using ColType = HisabPro.Web.ViewModel.Type;

namespace HisabPro.Web.Controllers
{
    [Authorize]
    public class ExpensesController : Controller
    {
        private readonly IExpenseService _expenseService;
        private readonly IAccountService _accountService;
        private readonly ICategoryService _categoryService;

        public ExpensesController(IExpenseService expenseService, IAccountService accountService, ICategoryService categoryService)
        {
            _expenseService = expenseService;
            _accountService = accountService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var req = new PageDataReq() { PageNumber = 1, PageSize = 10 };
            var model = await LoadGridData(req);
            return View(model);
        }
        public async Task<IActionResult> Load([FromBody] PageDataReq req)
        {
            var model = await LoadGridData(req);
            return PartialView("_GridViewBody", model);
        }

        public async Task<IActionResult> Save(int? id)
        {
            var accounts = await _accountService.GetAccountsAsync();
            accounts.Insert(0, new IdNameRes { Id = string.Empty, Name = string.Empty });
            ViewData["AccountId"] = new SelectList(accounts, "Id", "Name");

            var parentCategories = await _categoryService.GetParentCategoriesAsync();
            parentCategories.Insert(0, new IdNameRes { Id = string.Empty, Name = string.Empty });
            ViewData["ParentCategoryId"] = new SelectList(parentCategories, "Id", "Name");

            var childCategories = await _categoryService.GetChildCategoriesAsync();
            ViewData["ChildCategories"] = JsonSerializer.Serialize(childCategories);

            if (id != null)
            {
                var model = await _expenseService.GetByIdAsync(id.Value);
                ViewBag.SelectedChildCategoryId = model.ChildCategoryId;
                return View(model);
            }

            return View(new SaveExpense { IsActive = true, ExpenseOn = DateTime.Now });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save([Bind("Id,Title,ExpenseOn,Amount,Note,ParentCategoryId,ChildCategoryId,AccountId,IsActive")] SaveExpense req)
        {
            var response = await _expenseService.Save(req);
            return StatusCode((int)response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] DeleteReq req)
        {
            var response = await _expenseService.DeleteAsync(req.Id);
            return StatusCode((int)response.StatusCode, response); ;
        }

        /// <summary>
        /// This is used for generic gridview component which will perform sorting and pagination
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        private async Task<GridViewModel<object>> LoadGridData(PageDataReq req)
        {
            var pageData = await _expenseService.PageData(req);
            var model = new GridViewModel<object>
            {
                Columns = new List<Column> {
                    new Column() { Name = "Title", Width = "150px"  },
                    new Column() { Name = "ExpenseOn", Title = "Date", Type = ColType.Date, Width = "100px" },
                    new Column() { Name = "Amount", Align = Align.Right, Width="95px" },
                    new Column() { Name = "ParentCategory", Title = "Category", Width="140px" },
                    new Column() { Name = "ChildCategory", Title = "Sub Category", Width= "150px" },
                    new Column() { Name = "Account", Width = "100px" },
                    new Column() { Name = "Note"},
                    new Column() { Name = "Edit", Type = ColType.Edit, Width="50px" },
                    new Column() { Name = "Delete", Type = ColType.Delete, Width="50px" }
                },
                Data = pageData.Data.Cast<object>().ToList(),
                TotalRecords = pageData.TotalData,
                PageNumber = req.PageNumber,
                PageSize = req.PageSize,
                SortBy = req.SortBy,
                SortDirection = req.SortDirection
            };
            return model;
        }
    }
}
