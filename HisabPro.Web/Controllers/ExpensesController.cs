using HisabPro.DTO.Request;
using HisabPro.DTO.Response;
using HisabPro.Services.Implements;
using HisabPro.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Json;

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
            return View(await _expenseService.GetAll());
        }

        public async Task<IActionResult> Save(int? id)
        {
            var accounts = await _accountService.GetAccountsAsync();
            accounts.Insert(0, new IdNameRes { Id = 0, Name = "" });
            ViewData["AccountId"] = new SelectList(accounts, "Id", "Name");

            var parentCategories = await _categoryService.GetParentCategoriesAsync();
            parentCategories.Insert(0, new IdNameRes { Id = 0, Name = "" });
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
    }
}
