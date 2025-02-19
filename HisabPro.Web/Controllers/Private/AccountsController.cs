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
    public class AccountsController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly ISharedViewLocalizer _localizer;

        public AccountsController(IAccountService accountService, ISharedViewLocalizer localizer)
        {
            _accountService = accountService;
            _localizer = localizer;
        }

        public async Task<IActionResult> Index()
        {
            var fields = new List<BaseFilterModel>
            {
                new FilterModel<string> {
                    FieldName = "Name",
                    FieldTitle = _localizer.Get(ResourceKey.FieldName)
                },
                 new FilterModel<string> {
                    FieldName = "Mobile",
                    FieldTitle = _localizer.Get(ResourceKey.FieldMobile)
                },
                new FilterModel<DateTime> {
                    FieldName = "CreatedOn",
                    FieldTitle= _localizer.Get(ResourceKey.LabelFilterCreatedDateRange)
                },
                new FilterModel<bool> {
                    FieldName = "IsActive",
                    FieldTitle= _localizer.Get(ResourceKey.FieldIsActive)
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
            if (id != null)
            {
                var model = await _accountService.GetByIdAsync(id.Value);
                return View(model);

            }
            return View(new SaveAccountReq { IsActive = true });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save([Bind("Id,Name,FullName,Mobile,IsActive")] SaveAccountReq req)
        {
            var response = await _accountService.SaveAsync(req);
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
        private async Task<GridViewModel<object>> LoadGridData(LoadDataRequest req, bool firstTimeLoad = false)
        {
            var columns = new List<Column> {
                    new Column() { Name = "Name", Width = "140px", Title=_localizer.Get(ResourceKey.FieldName) },
                    new Column() { Name = "FullName", Title = _localizer.Get(ResourceKey.FieldFullName)},
                    new Column() { Name = "Mobile", Title=_localizer.Get(ResourceKey.FieldMobile), Width="120px" },
                    new Column() { Name = "IsActive", Title = _localizer.Get(ResourceKey.LabelColumnActive), Width="90px", Type = ColType.Checkbox },
                    new Column() { Name = "CreatedBy", Title = _localizer.Get(ResourceKey.LabelColumnCreatedBy), Width= "170px" },
                    new Column() { Name = "CreatedOn", Title = _localizer.Get(ResourceKey.LabelColumnCreatedOn), Type = ColType.Date, Width = "130px" },
                    new Column() { Name = "Edit", Type = ColType.Edit},
                    new Column() { Name = "Delete", Type = ColType.Delete}
            };
            return await GridviewHelper.LoadGridData(req, firstTimeLoad, _accountService.PageData, columns);
        }
    }
}
