using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Models
{
    public class Product
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public required string Name { get; set; }
        public required string Category { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; } = "https://via.placeholder.com/200x250?text=No+Image"; // Заглушка по умолчанию
        public string Description { get; set; } = "No description available.";
        public List<Review> Reviews { get; set; } = new();
        public List<ProductAttr> Attributes { get; set; } = new();
    }

    public record ProductAttr(string Name, string Value);

    // New class for the Review system
    public class Review
    {
        public required string User { get; set; }
        public required string Comment { get; set; }
        public int Rating { get; set; } // 1-5 stars
        public DateTime Date { get; set; } = DateTime.Now;
    }
}