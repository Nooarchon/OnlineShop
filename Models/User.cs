using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Models
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid(); // Generated automatically
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
