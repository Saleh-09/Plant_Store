using Azure.Core.Extensions;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult ProductsList()
        {
            var products = _context.Products
                .Select(p => new ProductDisplayViewModel
                {
                    Name = p.Name,
                    Description = p.Description,
                    Picture = p.Picture,
                    PictureFormat = $"data:image/png;base64,{Convert.ToBase64String(p.Picture)}",
                    Price = p.Price,
                    Stock = p.Stock
                }).ToList();

            return View(products);
        }
        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ProductViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            using var ms = new MemoryStream();
            model.Picture.CopyTo(ms);

            var product = new Product
            {
                Name = model.Name,
                Description = model.Description,
                Picture = ms.ToArray(),
                Price = model.Price,
                Stock = model.Stock
            };

            _context.Products.Add(product);
            _context.SaveChanges();
            ModelState.Clear();

            return RedirectToAction("ProductsList");
        }
    }
}
