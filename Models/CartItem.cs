using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Models
{
    public class CartItem
    {
        // Reference to the game object itself
        public Product Product { get; set; } = null!;

        // Quantity (here we will check the limit of 10 pieces)
        public int Quantity { get; set; }
    }
}
