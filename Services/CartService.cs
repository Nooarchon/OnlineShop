using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.Models;

namespace OnlineShop.Services
{
    public class CartService
    {
        // Dictionary: User's email -> List of items in their cart
        private readonly Dictionary<string, List<CartItem>> _userCarts = new();

        public string AddToCart(string email, Product product)
        {
            if (!_userCarts.ContainsKey(email))
                _userCarts[email] = new List<CartItem>();

            var cart = _userCarts[email];
            var existingItem = cart.FirstOrDefault(i => i.Product.Id == product.Id);

            if (existingItem != null)
            {
                // LIMIT CHECK: maximum 10 pieces of one product
                if (existingItem.Quantity >= 10)
                    return "Error: You cannot add more than 10 copies of the same game.";

                existingItem.Quantity++;
            }
            else
            {
                cart.Add(new CartItem { Product = product, Quantity = 1 });
            }

            return "Success: Game added to cart";
        }

        public List<CartItem> GetCart(string email)
        {
            return _userCarts.ContainsKey(email) ? _userCarts[email] : new List<CartItem>();
        }
    }

    public class CartItem
    {
        public Product Product { get; set; } = null!;
        public int Quantity { get; set; }
    }
}
