using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantStore.Models.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string CustomerName { get; set; } = default!;
        public int UserID { get; set; }
        public User User { get; set; } = default!;
        public ICollection<OrderItem> Items { get; set; } = default!;
    }
}
