using HisabPro.DTO.Request;
using HisabPro.Repository.Interfaces;
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
            var response = await _categoryRepository.CategoriesWithChilds();
            return View(response);
        }

        // POST: /Category/Save
        [HttpPost]
        public async Task<IActionResult> Save([FromBody] SaveCategoryDTO model)
        {
            var response = await _categoryRepository.SaveCategory(model);
            return StatusCode((int)response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] DeleteCategoryDTO request)
        {
            var response = await _categoryRepository.Delete(request);
            return StatusCode((int)response.StatusCode, response);
        }
    }
}
