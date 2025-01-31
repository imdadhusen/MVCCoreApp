using AutoMapper;
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
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;
using ColType = HisabPro.Web.ViewModel.Type;

namespace HisabPro.Web.Controllers.Private
{
    [Authorize]
    public class ExpensesController : Controller
    {
        private readonly IExpenseService _expenseService;
        private readonly IAccountService _accountService;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public ExpensesController(IExpenseService expenseService, IAccountService accountService, ICategoryService categoryService, IMapper mapper)
        {
            _expenseService = expenseService;
            _accountService = accountService;
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var parentCategories = await _categoryService.GetCategoriesAsync(EnumCategoryType.Expense);
            var childCategories = await _categoryService.GetSubCategoriesAsync(EnumCategoryType.Expense);
            var filters = new List<BaseFilterModel>
            {
                new FilterModel<int> {
                    FieldName = "CategoryId",
                    ChildFieldName = "SubCategoryId",
                    FieldTitle = SharedResource.LabelColumnCategory,
                    Items = _mapper.Map<List<IdNameAndRefId>>(parentCategories),
                    ChildItems = _mapper.Map<List<IdNameAndRefId>>(childCategories)
                },
                new FilterModel<int> {
                    FieldName = "SubCategoryId",
                    FieldTitle = SharedResource.FieldSubCategory
                },
                new FilterModel<string> {
                    FieldName = "Title",
                    FieldTitle= SharedResource.LabelColumnTitle
                },
                new FilterModel<string> {
                    FieldName = "Note",
                    FieldTitle = SharedResource.LabelFieldType
                },
                new FilterModel<DateTime> {
                    FieldName = "CreatedOn",
                    FieldTitle=SharedResource.LabelFilterDateRange
                },
                new FilterModel<bool> {
                    FieldName = "IsActive",
                    FieldTitle = SharedResource.FieldIsActive
                },
                new FilterModel<bool> {
                    FieldName = "IsBulkImported",
                    FieldTitle= SharedResource.LabelFilterBulkImported
                }
            };

            var req = new LoadDataRequest() { Filters = filters };
            var model = await LoadGridData(req, true);
            return View(model);
        }
        public async Task<IActionResult> Load([FromBody] LoadDataRequest req)
        {
            var model = await LoadGridData(req);
            return PartialView("~/Views/Shared/_GridViewBody.cshtml", model);
        }

        public async Task<IActionResult> Save(int? id)
        {
            var accounts = await _accountService.GetAccountsAsync();
            accounts.Insert(0, new IdNameRes { Id = string.Empty, Name = string.Empty });
            ViewData["AccountId"] = new SelectList(accounts, "Id", "Name");

            var parentCategories = await _categoryService.GetCategoriesAsync(EnumCategoryType.Expense);
            parentCategories.Insert(0, new IdNameRes { Id = string.Empty, Name = string.Empty });
            ViewData["CategoryId"] = new SelectList(parentCategories, "Id", "Name");

            ViewData["ChildCategories"] = JsonSerializer.Serialize(await _categoryService.GetSubCategoriesAsync(EnumCategoryType.Expense));

            if (id != null)
            {
                var model = await _expenseService.GetByIdAsync(id.Value);
                ViewBag.SelectedSubCategoryId = model.SubCategoryId;
                return View(model);
            }

            return View(new SaveExpenseReq { IsActive = true, ExpenseOn = DateTime.Now });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save([Bind("Id,Title,ExpenseOn,Amount,Note,CategoryId,SubCategoryId,AccountId,IsActive")] SaveExpenseReq req)
        {
            var response = await _expenseService.SaveAsync(req);
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
        private async Task<GridViewModel<object>> LoadGridData(LoadDataRequest req, bool firstTimeLoad = false)
        {
            var columns = new List<Column> {
                    new Column() { Name = "Title", Title = SharedResource.LabelFieldTitle, Width = "150px" },
                    new Column() { Name = "ExpenseOn", Title = SharedResource.FieldDate, Type = ColType.Date, Width = "100px" },
                    new Column() { Name = "Amount", Title = SharedResource.LabelFieldAmount, Align = Align.Right, Width = "95px" },
                    new Column() { Name = "Category", Title = SharedResource.FieldCategory, Width = "140px" },
                    new Column() { Name = "SubCategory", Title = SharedResource.FieldSubCategory, Width = "150px" },
                    new Column() { Name = "Account", Title = SharedResource.LabelFieldAccount, Width = "100px" },
                    new Column() { Name = "IsBulkImported", Title= SharedResource.LabelColumnImport, Width = "90px", Type = ColType.Checkbox },
                    new Column() { Name = "Note", Title = SharedResource.LabelFieldNote, IsSortable = false },
                    new Column() { Name = "Edit", Type = ColType.Edit},
                    new Column() { Name = "Delete", Type = ColType.Delete }
            };
            return await GridviewHelper.LoadGridData(req, firstTimeLoad, _expenseService.PageData, columns);
        }
    }
}
