using AutoMapper;
using HisabPro.Constants;
using HisabPro.DTO.Model;
using HisabPro.DTO.Request;
using HisabPro.DTO.Response;
using HisabPro.Repository.Interfaces;
using HisabPro.Services.Implements;
using HisabPro.Services.Interfaces;
using HisabPro.Web.Helper;
using HisabPro.Web.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ColType = HisabPro.Web.ViewModel.Type;

namespace HisabPro.Web.Controllers
{
    [Authorize]
    public class CategoryController(ICategoryService categoryService, IMapper mapper) : Controller
    {
        private readonly ICategoryService _categoryService = categoryService;
        private readonly IMapper _mapper = mapper;

        public async Task<IActionResult> Index()
        {
            var types = EnumHelper.ToIdNameList<EnumCategoryType>();
            var filters = new List<BaseFilterModel>
            {
                new FilterModel<string> {
                    FieldName = "Name"
                },
                new FilterModel<int> {
                    FieldName = "Type",
                    Items = _mapper.Map<List<IdNameAndRefId>>(types),
                },
                new FilterModel<DateTime> {
                    FieldName = "CreatedOn",
                    FieldTitle="Created Date Range"
                },
                new FilterModel<bool> {
                    FieldName = "IsStandard",
                    FieldTitle="Standard"
                }
            };
            var req = new LoadDataRequest() { Filters = filters };
            var model = await LoadGridData(req, true);
            return View(model);
            //var response = await _categoryRepository.CategoriesWithChilds();
            //return View(response);
        }

        public async Task<IActionResult> Load([FromBody] LoadDataRequest req)
        {
            var model = await LoadGridData(req);
            return PartialView("_GridBody", model.Data);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="category">1:Parent, 2:SubCategory</param>
        /// <returns></returns>
        public async Task<IActionResult> Save(int? id, int? category)
        {
            if (id != null)
            {
                var model = await _categoryService.GetByIdAsync(id.Value);
                SelectList? categoryList = null;
                if (model.ParentId.HasValue || category == 2)
                {
                    var categories = await _categoryService.GetAllParentCategoryByType(model.Type);
                    categoryList = new SelectList(categories, "Id", "Name", (category == 2) ? model.Id : model.ParentId);
                }
                ViewData["ParentCategories"] = categoryList;

                //Create subcategory under selected parent category
                if (!model.ParentId.HasValue && category == 2)
                {
                    model.Id = null;
                    model.Name = "";
                }
                return View(model);
            }
            return View(new SaveCategory());
        }

        // POST: /Category/Save
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save([Bind("Id,Name,ParentId,Type,IsStandard")] SaveCategory req)
        {
            var response = await _categoryService.SaveAsync(req);
            return StatusCode((int)response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] DeleteReq req)
        {
            var response = await _categoryService.DeleteAsync(req.Id);
            return StatusCode((int)response.StatusCode, response); ;
        }

        /// <summary>
        /// This is used for generic gridview component which will perform sorting and pagination
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        private async Task<GridViewModel<CategoryRes>> LoadGridData(LoadDataRequest req, bool firstTimeLoad = false)
        {
            var columns = new List<Column> {
                new Column() { Name = "Name"  },
                new Column() { Name = "Type", Width="140px" },
                new Column() { Name = "IsStandard", Title = "Standard", Width="120px", Type = ColType.Checkbox },
                new Column() { Name = "IsActive", Title = "Active", Width="120px", Type = ColType.Checkbox },
                new Column() { Name = "CreatedOn", Title ="Created On", Type = ColType.Date, Width = "130px" },
                new Column() { Name = "Edit", Type = ColType.Edit},
                new Column() { Name = "Delete", Type = ColType.Delete}
            };
            return await GridviewHelper.LoadGridDataStrongType(req, firstTimeLoad, _categoryService.PageData, columns);
        }
    }
}
