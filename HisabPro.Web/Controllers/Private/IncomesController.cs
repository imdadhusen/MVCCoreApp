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
using ColType = HisabPro.DTO.Model.Type;

namespace HisabPro.Web.Controllers.Private
{
    [Authorize]
    public class IncomesController : Controller
    {
        private readonly IIncomeService _incomeService;
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;
        private readonly ISharedViewLocalizer _localizer;
        private readonly IExportDataService _exportDataService;

        public IncomesController(IIncomeService incomeService, IAccountService accountService,
            IMapper mapper, ISharedViewLocalizer localizer, IExportDataService exportDataService)
        {
            _incomeService = incomeService;
            _accountService = accountService;
            _mapper = mapper;
            _localizer = localizer;
            _exportDataService = exportDataService;
        }

        public async Task<IActionResult> Index()
        {
            var accounts = await _accountService.GetAccountsAsync();
            var fields = new List<BaseFilterModel>
            {
                new FilterModel<string> {
                    FieldName = "Title",
                    FieldTitle= _localizer.Get(ResourceKey.FieldTitle),
                },
                new FilterModel<int> {
                    FieldName = "AccountId",
                    FieldTitle= _localizer.Get(ResourceKey.FieldAccount),
                    Items =  _mapper.Map<List<IdNameAndRefId>>(accounts),
                },
                new FilterModel<DateTime> {
                    FieldName = "IncomeOn",
                    FieldTitle= _localizer.Get(ResourceKey.LabelFilterDateRange)
                },
                new FilterModel<string> {
                    FieldName = "Note",
                    FieldTitle= _localizer.Get(ResourceKey.FieldNote),
                },
                new FilterModel<bool> {
                    FieldName = "IsActive",
                    FieldTitle= _localizer.Get(ResourceKey.FieldIsActive)
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

            if (id != null)
            {
                var model = await _incomeService.GetByIdAsync(id.Value);
                return View(model);

            }
            return View(new SaveIncomeReq { IsActive = true, IncomeOn = DateTime.Now });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save([Bind("Id,Title,IncomeOn,Amount,Note,AccountId,IsActive")] SaveIncomeReq req)
        {
            var response = await _incomeService.SaveAsync(req);
            return StatusCode((int)response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] DeleteReq req)
        {
            var response = await _incomeService.DeleteAsync(req.Id);
            return StatusCode((int)response.StatusCode, response); ;
        }

        [HttpPost]
        public async Task<IActionResult> Export([FromBody] ExportReq req)
        {
            var allPageData = await ExportDataHelper.GetData(req, _incomeService.ExportData);
            var data = allPageData.Data;
            return _exportDataService.Export(data, "Income Report", req, getGridColumns());
        }

        /// <summary>
        /// This is used for generic gridview component which will perform sorting and pagination
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        private async Task<GridViewModel<object>> LoadGridData(LoadDataRequest req, bool firstTimeLoad = false)
        {
            return await GridviewHelper.LoadGridData(req, firstTimeLoad, _incomeService.PageData, getGridColumns());
        }

        private List<Column> getGridColumns()
        {
            return new List<Column> {
                    new Column() { Name = "Title", Title = _localizer.Get(ResourceKey.FieldTitle), Width = "170px"  },
                    new Column() { Name = "IncomeOn", Title = _localizer.Get(ResourceKey.FieldDate), Type = ColType.Date, Width = "100px" },
                    new Column() { Name = "Amount", Title = _localizer.Get(ResourceKey.FieldAmount), Align = Align.Right, Width="95px" },
                    new Column() { Name = "Category", Title = _localizer.Get(ResourceKey.FieldCategory), Width = "140px" },
                    new Column() { Name = "SubCategory", Title = _localizer.Get(ResourceKey.FieldSubCategory), Width = "150px" },
                    new Column() { Name = "Account", Title = _localizer.Get(ResourceKey.FieldAccount), Width = "150px" },
                    new Column() { Name = "IsBulkImported", Title= _localizer.Get(ResourceKey.LabelColumnImport), Width = "90px", Type = ColType.Checkbox },
                    new Column() { Name = "Note", Title = _localizer.Get(ResourceKey.FieldNote), IsSortable = false},
                    new Column() { Name = "Edit", Type = ColType.Edit },
                    new Column() { Name = "Delete", Type = ColType.Delete }
            };
        }
    }
}
