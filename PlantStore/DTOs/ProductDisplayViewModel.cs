using PlantStore.Models.Models;

namespace PlantStore.DTOs
{
    public class ProductDisplayViewModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public byte[] Picture { get; set; }
        public string PictureFormat { get; set; } = default!;
        public decimal Price { get; set; }
        public int Stock { get; set; }

    }
}
