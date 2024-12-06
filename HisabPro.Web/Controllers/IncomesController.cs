using AutoMapper;
using HisabPro.DTO.Model;
using HisabPro.DTO.Request;
using HisabPro.DTO.Response;
using HisabPro.Services.Interfaces;
using HisabPro.Web.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ColType = HisabPro.Web.ViewModel.Type;

namespace HisabPro.Web.Controllers
{
    [Authorize]
    public class IncomesController : Controller
    {
        private readonly IIncomeService _incomeService;
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;
        public IncomesController(IIncomeService incomeService, IAccountService accountService, IMapper mapper)
        {
            _incomeService = incomeService;
            _accountService = accountService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var accounts = await _accountService.GetAccountsAsync();
            var filters = new List<BaseFilterModel>
            {
                new FilterModel<string> {
                    FieldName = "Title"
                },
                new FilterModel<int> {
                    FieldName = "AccountId",
                    FieldTitle="Account",
                    Items =  _mapper.Map<List<IdNameAndRefId>>(accounts),
                },
                new FilterModel<DateTime> {
                    FieldName = "IncomeOn",
                    FieldTitle="Date Range"
                },
                new FilterModel<string> {
                    FieldName = "Note"
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
            var model = await LoadGridData(req);
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

            if (id != null)
            {
                var model = await _incomeService.GetByIdAsync(id.Value);
                return View(model);

            }
            return View(new SaveIncome { IsActive = true, IncomeOn = DateTime.Now });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save([Bind("Id,Title,IncomeOn,Amount,Note,AccountId,IsActive")] SaveIncome req)
        {
            var response = await _incomeService.Save(req);
            return StatusCode((int)response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] DeleteReq req)
        {
            var response = await _incomeService.DeleteAsync(req.Id);
            return StatusCode((int)response.StatusCode, response); ;
        }

        /// <summary>
        /// This is used for generic gridview component which will perform sorting and pagination
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        private async Task<GridViewModel<object>> LoadGridData(LoadDataRequest req)
        {
            var pageData = await _incomeService.PageData(req);
            var model = new GridViewModel<object>
            {
                Columns = new List<Column> {
                    new Column() { Name = "Title", Width = "170px"  },
                    new Column() { Name = "IncomeOn", Title = "Date", Type = ColType.Date, Width = "100px" },
                    new Column() { Name = "Amount", Align = Align.Right, Width="95px" },
                    new Column() { Name = "Account", Width = "150px" },
                    new Column() { Name = "Note", IsSortable = false},
                    new Column() { Name = "IsActive", Width = "90px" },
                    new Column() { Name = "Edit", Type = ColType.Edit },
                    new Column() { Name = "Delete", Type = ColType.Delete }
                },
                Data = pageData.Data.Cast<object>().ToList(),
                TotalRecords = pageData.TotalData,
                PageNumber = req.PageData.PageNumber,
                PageSize = req.PageData.PageSize,
                SortBy = req.PageData.SortBy,
                SortDirection = req.PageData.SortDirection,
                Filters = req.Filters
            };
            return model;
        }
    }
}
