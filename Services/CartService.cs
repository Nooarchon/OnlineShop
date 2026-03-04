using System;
using System.Collections.Generic;
using System.Linq;
using OnlineShop.Models;

namespace OnlineShop.Services
{
    public class CartService
    {
        // Dictionary: User's email -> List of items in the cart
        private readonly Dictionary<string, List<CartItem>> _userCarts = new();

        public string AddToCart(string email, Product product)
        {
            if (!_userCarts.ContainsKey(email))
                _userCarts[email] = new List<CartItem>();

            var cart = _userCarts[email];
            var existingItem = cart.FirstOrDefault(i => i.Product.Id == product.Id);

            if (existingItem != null)
            {
                // Just increase the quantity without checking
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

        public void RemoveFromCart(string email, string productId)
        {
            if (_userCarts.ContainsKey(email))
            {
                var item = _userCarts[email].FirstOrDefault(i => i.Product.Id == productId);
                if (item != null)
                {
                    _userCarts[email].Remove(item);
                }
            }
        }

        // Add a method to completely clear the cart after payment
        public void ClearCart(string email)
        {
            if (_userCarts.ContainsKey(email))
            {
                _userCarts[email].Clear();
            }
        }
    }

    public class CartItem
    {
        public Product Product { get; set; } = null!;
        public int Quantity { get; set; }
    }
}