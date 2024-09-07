using HisabPro.DTO.Request;
using HisabPro.Repository.Interfaces;
using HisabPro.Web.Helper;
using HisabPro.Web.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Save([FromBody] SaveRequestDTO model)
        {
            try
            {
                var (message, errors) = ValidationHelper.GetValidationErrors(ModelState);
                if (message != "")
                {
                    return BadRequest(new { message, errors });
                }
                else
                {
                    var res = _categoryRepository.SaveCategory(model);
                    return Ok(res);
                }
            }
            catch(Exception ex)
            {
                //TODO: in prod don't expose actual error instead "Internal Server Error"
                return StatusCode(500, ex.Message);
            }
        }
    }
}
