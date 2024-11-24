using HisabPro.DTO.Request;
using HisabPro.Services.Interfaces;
using HisabPro.Web.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ColType = HisabPro.Web.ViewModel.Type;

namespace HisabPro.Web.Controllers
{
    [Authorize]
    public class AccountsController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountsController(IAccountService accountService)
        {
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
            if (id != null)
            {
                var model = await _accountService.GetByIdAsync(id.Value);
                return View(model);

            }
            return View(new SaveAccount { IsActive = true });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save([Bind("Id,Name,FullName,Mobile,IsActive")] SaveAccount req)
        {
            var response = await _accountService.Save(req);
            return StatusCode((int)response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] DeleteReq req)
        {
            var response = await _accountService.DeleteAsync(req.Id);
            return StatusCode((int)response.StatusCode, response); ;
        }

        /// <summary>
        /// This is used for generic gridview component which will perform sorting and pagination
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        private async Task<GridViewModel<object>> LoadGridData(PageDataReq req)
        {
            var pageData = await _accountService.PageData(req);
            var model = new GridViewModel<object>
            {
                Columns = new List<Column> {
                    new Column() { Name = "Name", Width = "140px"  },
                    new Column() { Name = "FullName", Title = "Full Name"},
                    new Column() { Name = "Mobile", Width="120px" },
                    new Column() { Name = "IsActive", Title = "Active", Width="90px" },
                    new Column() { Name = "CreatedBy", Title = "Created By", Width= "170px" },
                    new Column() { Name = "CreatedOn", Title ="Created On", Type = ColType.Date, Width = "130px" },
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
