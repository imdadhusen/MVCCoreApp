﻿using AutoMapper;
using HisabPro.Constants;
using HisabPro.Constants.Resources;
using HisabPro.DTO.Model;
using HisabPro.DTO.Request;
using HisabPro.DTO.Response;
using HisabPro.Services.Interfaces;
using HisabPro.Web.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ColType = HisabPro.DTO.Model.Type;

namespace HisabPro.Web.Controllers.Private
{
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        private readonly ISharedViewLocalizer _localizer;
        private readonly IExportDataService _exportDataService;

        public CategoryController(ICategoryService categoryService, IMapper mapper, ISharedViewLocalizer localizer, IExportDataService exportDataService)
        {
            _categoryService = categoryService;
            _mapper = mapper;
            _localizer = localizer;
            _exportDataService = exportDataService;
            // Configure generic helper for Enum
            EnumLocalizationHelper.Configure(_localizer);
        }

        public async Task<IActionResult> Index()
        {
            var types = EnumHelper.ToIdNameList<EnumCategoryType>(_localizer);
            var fields = new List<BaseFilterModel>
            {
                new FilterModel<string> {
                    FieldName = "Name",
                    FieldTitle = _localizer.Get(ResourceKey.FieldName)
                },
                new FilterModel<int> {
                    FieldName = "Type",
                    FieldTitle = _localizer.Get(ResourceKey.FieldType),
                    Items = _mapper.Map<List<IdNameAndRefId>>(types),
                },
                new FilterModel<DateTime> {
                    FieldName = "CreatedOn",
                    FieldTitle= _localizer.Get(ResourceKey.LabelFilterCreatedDateRange)
                },
                new FilterModel<bool> {
                    FieldName = "IsStandard",
                    FieldTitle= _localizer.Get(ResourceKey.LabelFilterStandard)
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
            SaveCategoryReq model = new SaveCategoryReq();
            if (id != null)
            {
                model = await _categoryService.GetByIdAsync(id.Value);
                SelectList? categoryList = null;
                if (model.ParentId.HasValue || category == 2)
                {
                    var categories = await _categoryService.GetAllParentCategoryByType(model.Type);
                    categoryList = new SelectList(categories, "Id", "Name", category == 2 ? model.Id : model.ParentId);
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

            //Allow parent category to select type 
            if (model.Id == null && model.ParentId == null)
            {
                var types = EnumHelper.ToIdNameList<EnumCategoryType>(_localizer);
                ViewData["Types"] = types;
            }
            return View(model);
        }

        // POST: /Category/Save
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save([Bind("Id,Name,ParentId,Type,IsStandard")] SaveCategoryReq req)
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

        [HttpPost]
        public async Task<IActionResult> Export([FromBody] ExportReq req)
        {
            var allPageData = await ExportDataHelper.GetData(req, _categoryService.ExportData);
            var data = allPageData.Data;
            return _exportDataService.Export(data, EnumReportTitle.CategoryAndSubcategory, req, getGridColumns());
        }

        /// <summary>
        /// This is used for generic gridview component which will perform sorting and pagination
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        private async Task<GridViewModel<CategoryRes>> LoadGridData(LoadDataRequest req, bool firstTimeLoad = false)
        {
            return await GridviewHelper.LoadGridDataStrongType(req, firstTimeLoad, _categoryService.PageData, getGridColumns());
        }

        private List<Column> getGridColumns()
        {
            return new List<Column> {
                new Column() { Name = "Name", Title = _localizer.Get(ResourceKey.FieldName) },
                new Column() { Name = "Type", Title = _localizer.Get(ResourceKey.FieldType), Width="140px" },
                new Column() { Name = "IsStandard", Title = _localizer.Get(ResourceKey.LabelFilterStandard), Width="120px", Type = ColType.Checkbox },
                new Column() { Name = "IsActive", Title = _localizer.Get(ResourceKey.LabelColumnActive), Width="120px", Type = ColType.Checkbox },
                new Column() { Name = "CreatedOn", Title = _localizer.Get(ResourceKey.LabelColumnCreatedOn), Type = ColType.Date, Width = "130px" },
                new Column() { Name = "Edit", Type = ColType.Edit},
                new Column() { Name = "Delete", Type = ColType.Delete}
            };
        }
    }
}
