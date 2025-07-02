using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PlantStore.DataAccess.Data;
using PlantStore.DTOs;
namespace PlantStore.Controllers
{
    public class CustomerController : Controller
    {
        private readonly StoreDbContext _context;
        public CustomerController(StoreDbContext context)
        {
            _context = context;
        }

        public IActionResult UserProductList(int? categoryId)
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
                    ProductId = p.ProductId,
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
    }
}
