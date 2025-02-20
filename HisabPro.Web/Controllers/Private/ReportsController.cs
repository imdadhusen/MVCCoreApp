using AutoMapper;
using HisabPro.Constants;
using HisabPro.Constants.Resources;
using HisabPro.DTO.Model;
using HisabPro.DTO.Request;
using HisabPro.Services.Interfaces;
using HisabPro.Web.Helper;
using HisabPro.Web.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ColType = HisabPro.Web.ViewModel.Type;

namespace HisabPro.Web.Controllers.Private
{
    [Authorize]
    public class ReportsController : Controller
    {
        private readonly ISharedViewLocalizer _localizer;
        private readonly ICategoryService _categoryService;
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;
        private readonly IReportService _reportService;

        public ReportsController(ISharedViewLocalizer localizer, ICategoryService categoryService, IAccountService accountService, IMapper mapper, IReportService reportService)
        {
            _localizer = localizer;
            _categoryService = categoryService;
            _accountService = accountService;
            _mapper = mapper;
            _reportService = reportService;
        }

        public async Task<IActionResult> Index()
        {
            var parentCategories = await _categoryService.GetCategoriesAsync(EnumCategoryType.Expense);
            var childCategories = await _categoryService.GetSubCategoriesAsync(EnumCategoryType.Expense);
            var accounts = await _accountService.GetAccountsAsync();
            var types = EnumHelper.ToIdNameList<EnumCategoryType>(_localizer);

            var fields = new List<BaseFilterModel>
            {
                new FilterModel<DateTime> {
                    FieldName = "TransactionOn",
                    FieldTitle = _localizer.Get(ResourceKey.FieldDate)
                },
                new FilterModel<string> {
                    FieldName = "Title",
                    FieldTitle = _localizer.Get(ResourceKey.FieldTitle)
                },
                new FilterModel<int> {
                    FieldName = "TypeId",
                    FieldTitle = _localizer.Get(ResourceKey.FieldType),
                    Items = _mapper.Map<List<IdNameAndRefId>>(types),
                },
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
                new FilterModel<int> {
                    FieldName = "AccountId",
                    FieldTitle= _localizer.Get(ResourceKey.FieldAccount),
                    Items =  _mapper.Map<List<IdNameAndRefId>>(accounts),
                },
                new FilterModel<double> {
                    FieldName = "Amount",
                    FieldTitle= _localizer.Get(ResourceKey.FieldAmount)
                }
            };
            var filter = new FilterViewModel
            {
                Fields = fields,
                HasCreateNew = false
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

        /// <summary>
        /// This is used for generic gridview component which will perform sorting and pagination
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        private async Task<GridViewModel<object>> LoadGridData(LoadDataRequest req, bool firstTimeLoad = false)
        {
            var columns = new List<Column> {
                new Column() { Name = "TransactionOn", Title = _localizer.Get(ResourceKey.FieldDate), Type = ColType.Date, Width = "100px" }, //Income or Expense transaction date
                new Column() { Name = "Title", Title = _localizer.Get(ResourceKey.FieldTitle), Width = "170px"  },
                new Column() { Name = "Category", Title = _localizer.Get(ResourceKey.FieldCategory), Width = "140px" },
                new Column() { Name = "SubCategory", Title = _localizer.Get(ResourceKey.FieldSubCategory), Width = "150px" },
                new Column() { Name = "Amount", Title = _localizer.Get(ResourceKey.FieldAmount), Align = Align.Right, Width="95px" },
                new Column() { Name = "Account", Title = _localizer.Get(ResourceKey.FieldAccount), Width = "150px" },
                new Column() { Name = "Type", Title = _localizer.Get(ResourceKey.FieldType), Width = "150px" }, //Type: Income or Expense
                new Column() { Name = "Note", Title = _localizer.Get(ResourceKey.FieldNote), IsSortable = false}
            };
            return await GridviewHelper.LoadGridData(req, firstTimeLoad, _reportService.PageData, columns);
        }
    }
}
