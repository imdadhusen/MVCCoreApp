using HisabPro.DTO.Request;
using HisabPro.Repository.Interfaces;
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
            if (ModelState.IsValid)
            {
                // Handle your post logic here
                return Json(new { Status = "Success", Data = model });
            }
            return BadRequest(ModelState);
        }
    }
}
