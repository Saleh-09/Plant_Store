using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantStore.Models.Models
{
    public class User
    {
        public int UserId { get; set; }                   
        public string Name { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
        public string Role { get; set; } = default!;              
        public ICollection<Order> Orders { get; set; }= default!;
    }
}
