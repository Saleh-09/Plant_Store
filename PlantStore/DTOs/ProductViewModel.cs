using Microsoft.AspNetCore.Mvc.Rendering;
using PlantStore.Models.Models;

namespace PlantStore.DTOs
{
    public class ProductViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IFormFile Picture { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; } = new List<SelectListItem>();
    }
}
