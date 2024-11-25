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
        public IncomesController(IIncomeService incomeService, IAccountService accountService)
        {
            _incomeService = incomeService;
            _accountService = accountService;
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
        private async Task<GridViewModel<object>> LoadGridData(PageDataReq req)
        {
            var pageData = await _incomeService.PageData(req);
            var model = new GridViewModel<object>
            {
                Columns = new List<Column> {
                    new Column() { Name = "Title", Width = "170px"  },
                    new Column() { Name = "IncomeOn", Title = "Date", Type = ColType.Date, Width = "100px" },
                    new Column() { Name = "Amount", Align = Align.Right, Width="95px" },
                    new Column() { Name = "Account", Width = "100px" },
                    new Column() { Name = "Note", IsSortable = false},
                    new Column() { Name = "IsActive", Width = "80px" },
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
