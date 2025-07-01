using System.ComponentModel.DataAnnotations;

namespace PlantStore.DTOs
{
    public class CategoryViewModel
    {
        [Required(ErrorMessage = "Category ID is required.")]
        public string Name { get; set; } = default!;
    }
}
