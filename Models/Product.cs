using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace OnlineShop.Models
{
    public class Product
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        // Добавляем 'required' или значение по умолчанию, чтобы убрать Warning CS8618
        public required string Name { get; set; }
        public required string Category { get; set; }

        public decimal Price { get; set; }
        public List<ProductAttr> Attributes { get; set; } = new();
    }

    // Убедитесь, что эта строка находится ВНУТРИ того же namespace или доступна публично
    public record ProductAttr(string Name, string Value);
}