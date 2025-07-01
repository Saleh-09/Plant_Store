using Azure.Core.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PlantStore.DataAccess.Data;
using PlantStore.DTOs;
using PlantStore.Models.Models;
namespace PlantStore.Controllers

{
    public class ProductsController : Controller
    {
        private readonly StoreDbContext _context;
        public ProductsController(StoreDbContext context)
        {
            this._context = context;
        }
        public IActionResult ProductList(int? categoryId)
        {
            var categories = _context.Categories
         .Select(c => new SelectListItem
         {
             Value = c.CategoryId.ToString(),
             Text = c.Name
         }).ToList();

            var productsQuery = _context.Products.AsQueryable();

            if (categoryId.HasValue && categoryId.Value > 0)
            {
                productsQuery = productsQuery.Where(p => p.CategoryId == categoryId.Value);
            }

            var products = productsQuery
                .Select(p => new ProductDisplayViewModel
                {
                    Name = p.Name,
                    Description = p.Description,
                    Picture = p.Picture,
                    PictureFormat = $"data:image/png;base64,{Convert.ToBase64String(p.Picture)}",
                    Price = p.Price,
                    Stock = p.Stock
                }).ToList();

            ViewBag.Categories = categories;
            ViewBag.SelectedCategory = categoryId ?? 0;

            return View(products);
        }
  
        [HttpGet]
        public IActionResult AddProduct()
        {
            var model = new ProductViewModel
            {
                Categories = _context.Categories
                    .Select(c => new SelectListItem
                    {
                        Value = c.CategoryId.ToString(),
                        Text = c.Name
                    }).ToList()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult AddProduct(ProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                // Repopulate categories if validation fails
                model.Categories = _context.Categories
                    .Select(c => new SelectListItem
                    {
                        Value = c.CategoryId.ToString(),
                        Text = c.Name
                    }).ToList();
                return View(model);
            }

            using var ms = new MemoryStream();
            model.Picture.CopyTo(ms);
            
            var product = new Product
            {
                Name = model.Name,
                Description = model.Description,
                Picture = ms.ToArray(),
                PictureFormat = model.Picture.ContentType,
                Price = model.Price,
                Stock = model.Stock,
                CategoryId = model.CategoryId
            };

            _context.Products.Add(product);
            _context.SaveChanges();
            ModelState.Clear();

            return RedirectToAction("ProductList");
        }
    }
}
