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

        [HttpPost]
        public IActionResult Add()
        {
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Update()
        {
            //var existingItem = items.Find(i => i.Id == item.Id);
            //if (existingItem != null)
            //{
            //    existingItem.Name = item.Name;
            //    existingItem.Email = item.Email;
            //}
            return RedirectToAction("Index");
        }
    }

    //public class Item
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //    public string Email { get; set; }
    //}
}
