using Azure;
using HisabPro.Constants;
using HisabPro.DTO.Model;
using HisabPro.DTO.Request;
using HisabPro.DTO.Response;
using HisabPro.Repository.Interfaces;
using HisabPro.Web.Helper;
using HisabPro.Web.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace HisabPro.Web.Controllers
{
    [Authorize]
    public class CategoryController(ICategoryRepository categoryRepository) : Controller
    {
        private readonly ICategoryRepository _categoryRepository = categoryRepository;

        [HttpGet("category/Index")]
        public async Task<IActionResult> Index()
        {
            CategoryModel categoryDetail = new CategoryModel
            {
                AllCategoryList = await _categoryRepository.GetCategories(),
                ParentCategoryList = await _categoryRepository.GetParentCategories(),
                ChildCategoryList = await _categoryRepository.GetChildCategories()
            };
            //return Ok(categories);
            return View(categoryDetail);
        }

        // POST: /Category/Save
        [HttpPost]
        public async Task<IActionResult> Save([FromBody] SaveCategoryDTO model)
        {
            var (message, errors) = ValidationHelper.GetValidationErrors(ModelState);
            if (message != "")
            {
                var response = new ResponseDTO<List<string>>
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = message,
                    Response = errors
                };
                return BadRequest(response);
            }
            else
            {
                var response = await _categoryRepository.SaveCategory(model);
                return StatusCode((int)response.StatusCode, response);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] DeleteCategoryDTO request)
        {
            var response = await _categoryRepository.Delete(request);
            return StatusCode((int)response.StatusCode, response);
        }
    }
}
