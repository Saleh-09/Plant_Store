using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlantStore.DataAccess.Data;
using PlantStore.DTOs;
using PlantStore.Models.Models;

namespace PlantStore.Controllers
{
    [Authorize(Roles = "admin")]
    public class CategoriesController : Controller
    {
        private readonly StoreDbContext _context;
        public CategoriesController(StoreDbContext context)
        {
            this._context = context;
        }
        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCategory(CategoryViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var category = new Category
            {
                Name = model.Name
            };

            ModelState.Clear();
            _context.Categories.Add(category);
            _context.SaveChanges();
            return RedirectToAction("AddCategory");
        }
    }
}
