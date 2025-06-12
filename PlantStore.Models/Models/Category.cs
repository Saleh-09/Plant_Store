using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantStore.Models.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; } = default!;

        public ICollection<Product> Products { get; set; } = default!;
    }
}
