using Azure.Core.Extensions;
using Microsoft.AspNetCore.Mvc;
using PlantStore.DataAccess.Data;
using PlantStore.DTOs;
namespace PlantStore.Controllers

{
    public class ProductsController : Controller
    {
        private readonly StoreDbContext _context;
        public ProductsController(StoreDbContext context)
        {
            this._context = context;
        }
        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(produ product)
        {
            
        }
    }
}
