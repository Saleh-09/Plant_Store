using PlantStore.Models.Models;

namespace PlantStore.DTOs
{
    public class ProductViewModel
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public IFormFile Picture { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}
