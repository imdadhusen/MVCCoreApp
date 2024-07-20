using Microsoft.AspNetCore.Mvc;

namespace HisabPro.Web.Controllers
{
    //[Authorize]
    public class CategoryController : Controller
    {
        private static readonly List<Item> items =
        [
            new Item { Id = 1, Name = "John Doe", Email = "john@example.com" },
            new Item { Id = 2, Name = "Jane Smith", Email = "jane@example.com" }
        ];

        [HttpGet("category/Index")]
        public IActionResult Index()
        {
            return View(items);
        }

        [HttpPost]
        public IActionResult Add(Item item)
        {
            item.Id = items.Count + 1;
            items.Add(item);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Update(Item item)
        {
            var existingItem = items.Find(i => i.Id == item.Id);
            if (existingItem != null)
            {
                existingItem.Name = item.Name;
                existingItem.Email = item.Email;
            }
            return RedirectToAction("Index");
        }
    }

    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
