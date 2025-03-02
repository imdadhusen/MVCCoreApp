using AutoMapper;
using HisabPro.Constants;
using HisabPro.Constants.Resources;
using HisabPro.DTO.Model;
using HisabPro.DTO.Request;
using HisabPro.DTO.Response;
using HisabPro.Services.Implements;
using HisabPro.Services.Interfaces;
using HisabPro.Web.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Json;
using ColType = HisabPro.DTO.Model.Type;

namespace HisabPro.Web.Controllers.Private
{
    [Authorize]
    public class ExpensesController : Controller
    {
        private readonly IExpenseService _expenseService;
        private readonly IAccountService _accountService;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        private readonly ISharedViewLocalizer _localizer;

        public ExpensesController(IExpenseService expenseService, IAccountService accountService, ICategoryService categoryService, IMapper mapper, ISharedViewLocalizer localizer)
        {
            _expenseService = expenseService;
            _accountService = accountService;
            _categoryService = categoryService;
            _mapper = mapper;
            _localizer = localizer;
        }

        public async Task<IActionResult> Index()
        {
            var parentCategories = await _categoryService.GetCategoriesAsync(EnumCategoryType.Expense);
            var childCategories = await _categoryService.GetSubCategoriesAsync(EnumCategoryType.Expense);
            var fields = new List<BaseFilterModel>
            {
                new FilterModel<int> {
                    FieldName = "CategoryId",
                    ChildFieldName = "SubCategoryId",
                    FieldTitle = _localizer.Get(ResourceKey.FieldCategory),
                    Items = _mapper.Map<List<IdNameAndRefId>>(parentCategories),
                    ChildItems = _mapper.Map<List<IdNameAndRefId>>(childCategories)
                },
                new FilterModel<int> {
                    FieldName = "SubCategoryId",
                    FieldTitle = _localizer.Get(ResourceKey.FieldSubCategory)
                },
                new FilterModel<string> {
                    FieldName = "Title",
                    FieldTitle= _localizer.Get(ResourceKey.FieldTitle)
                },
                new FilterModel<string> {
                    FieldName = "Note",
                    FieldTitle = _localizer.Get(ResourceKey.FieldType)
                },
                new FilterModel<DateTime> {
                    FieldName = "CreatedOn",
                    FieldTitle=_localizer.Get(ResourceKey.LabelFilterDateRange)
                },
                new FilterModel<bool> {
                    FieldName = "IsActive",
                    FieldTitle = _localizer.Get(ResourceKey.FieldIsActive)
                },
                new FilterModel<bool> {
                    FieldName = "IsBulkImported",
                    FieldTitle= _localizer.Get(ResourceKey.LabelFilterBulkImported)
                }
            };
            var filter = new FilterViewModel
            {
                Fields = fields,
            };
            var req = new LoadDataRequest() { Filter = filter };
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
                    new Column() { Name = "Title", Title = _localizer.Get(ResourceKey.FieldTitle), Width = "150px" },
                    new Column() { Name = "ExpenseOn", Title = _localizer.Get(ResourceKey.FieldDate), Type = ColType.Date, Width = "100px" },
                    new Column() { Name = "Amount", Title = _localizer.Get(ResourceKey.FieldAmount), Align = Align.Right, Width = "95px" },
                    new Column() { Name = "Category", Title = _localizer.Get(ResourceKey.FieldCategory), Width = "140px" },
                    new Column() { Name = "SubCategory", Title = _localizer.Get(ResourceKey.FieldSubCategory), Width = "150px" },
                    new Column() { Name = "Account", Title = _localizer.Get(ResourceKey.FieldAccount), Width = "100px" },
                    new Column() { Name = "IsBulkImported", Title= _localizer.Get(ResourceKey.LabelColumnImport), Width = "90px", Type = ColType.Checkbox },
                    new Column() { Name = "Note", Title = _localizer.Get(ResourceKey.FieldNote), IsSortable = false },
                    new Column() { Name = "Edit", Type = ColType.Edit},
                    new Column() { Name = "Delete", Type = ColType.Delete }
            };
            return await GridviewHelper.LoadGridData(req, firstTimeLoad, _expenseService.PageData, columns);
        }
    }
}
