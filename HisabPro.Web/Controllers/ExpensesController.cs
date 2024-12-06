using AutoMapper;
using HisabPro.DTO.Model;
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
            var parentCategories = await _categoryService.GetParentCategoriesAsync();
            var childCategories = await _categoryService.GetChildCategoriesAsync();
            var filters = new List<BaseFilterModel>
            {
                new FilterModel<int> {
                    FieldName = "ParentCategoryId",
                    ChildFieldName="ChildCategoryId",
                    FieldTitle="Category",
                    Items =  _mapper.Map<List<IdNameAndRefId>>(parentCategories),
                    ChildItems = _mapper.Map<List<IdNameAndRefId>>(childCategories)
                },
                new FilterModel<int> {
                    FieldName = "ChildCategoryId",
                    FieldTitle="Sub Category"
                },
                new FilterModel<string> {
                    FieldName = "Title",
                    FieldTitle="Title"
                },
                new FilterModel<string> {
                    FieldName = "Note"
                },
                new FilterModel<DateTime> {
                    FieldName = "CreatedOn",
                    FieldTitle="Date Range"
                },
                new FilterModel<bool> {
                    FieldName = "IsActive",
                    FieldTitle="Is Active"
                }
            };

            var req = new LoadDataRequest()
            {
                PageData = new PageDataReq() { PageNumber = 1, PageSize = 10 },
                Filters = filters
            };
            var model = await LoadGridData(req, true);
            return View(model);
        }
        public async Task<IActionResult> Load([FromBody] LoadDataRequest req)
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

            ViewData["ChildCategories"] = JsonSerializer.Serialize(await _categoryService.GetChildCategoriesAsync());

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
        private async Task<GridViewModel<object>> LoadGridData(LoadDataRequest req, bool firstTimeLoad = false)
        {
            var model = new GridViewModel<object>()
            {
                PageNumber = req.PageData.PageNumber,
                PageSize = req.PageData.PageSize,
                SortBy = req.PageData.SortBy,
                SortDirection = req.PageData.SortDirection,
                Columns = new List<Column> {
                    new Column() { Name = "Title", Width = "150px" },
                    new Column() { Name = "ExpenseOn", Title = "Date", Type = ColType.Date, Width = "100px" },
                    new Column() { Name = "Amount", Align = Align.Right, Width = "95px" },
                    new Column() { Name = "ParentCategory", Title = "Category", Width = "140px" },
                    new Column() { Name = "ChildCategory", Title = "Sub Category", Width = "150px" },
                    new Column() { Name = "Account", Width = "100px" },
                    new Column() { Name = "Note", IsSortable = false },
                    new Column() { Name = "Edit", Type = ColType.Edit},
                    new Column() { Name = "Delete", Type = ColType.Delete }
                }
            };

            if (firstTimeLoad)
            {
                model.Filters = req.Filters;
                req.Filters = null;
            }

            var pageData = await _expenseService.PageData(req);
            model.Data = pageData.Data.Cast<object>().ToList();
            model.TotalRecords = pageData.TotalData;
            return model;
        }
    }
}
