using Microsoft.AspNetCore.Mvc;
using mvcEntity.Data;
using mvcEntity.Models;

namespace mvcEntity.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AplicationDbContext _db;
        public CategoryController(AplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Category> ObjcCategoriesList = _db.Categories.ToList();
            return View(ObjcCategoriesList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if(obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "Category name and display order can not be same.");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
