using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace OnlineShop.Models
{
    public class Product
    {
        // Change int to string to store Guid
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public List<ProductAttr> Attributes { get; set; } = new();
    }

    public record ProductAttr(string Name, string Value);
}