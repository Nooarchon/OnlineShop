using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.Models;

namespace OnlineShop.Services;
public class StoreService
{
    private List<Product> _products = new();

    public StoreService()
    {
        // Fill the catalog with your list
        AddGame("Clair Obscur", "RPG", "Sandfall Interactive");
        AddGame("Kingdom Come: Deliverance", "RPG", "Warhorse Studios");
        AddGame("Silent Hill", "Horror", "Konami");
        AddGame("Resident Evil", "Horror", "Capcom");
        AddGame("Disco Elysium", "RPG", "ZA/UM");
        AddGame("Dragon Age", "RPG", "BioWare");
        AddGame("GTA 5", "Action", "Rockstar Games");
        AddGame("Manhunt", "Stealth", "Rockstar Games");
        AddGame("Little Nightmares", "Horror", "Tarsier Studios");
        AddGame("Wolf Among Us", "Adventure", "Telltale Games");
        AddGame("Walking dead", "Adventure", "Telltale Games");
        AddGame("Dispatch", "Interactive Movie", "Adhoc studious");
        AddGame("Ghost of Tsushima", "Action", "Sucker Punch");
        AddGame("Ghost of Yotei", "Action", "Sucker Punch");
        AddGame("Life is Strange", "Adventure", "Dontnod");
        AddGame("Heavy Rain", "Interactive Movie", "Quantic Dream");
        AddGame("Detroit: Become Human", "Interactive Movie", "Quantic Dream");
        AddGame("Until Dawn", "Horror", "Supermassive Games");
        AddGame("Devil May Cry", "Action", "Capcom");
        AddGame("Death Stranding", "Action", "Kojima Productions");
        AddGame("Metal Gear", "Stealth", "Konami");
        AddGame("Reanimal", "Horror", "Tarsier Studios");
        AddGame("Mafia", "Action", "2K Czech");
    }

    private void AddGame(string name, string genre, string dev)
    {
        _products.Add(new Product
        {
            Id = _products.Count + 1,
            Name = name,
            Price = 59.99m,
            Attributes = new() {
                new ProductAttr("Genre", genre),
                new ProductAttr("Developer", dev)
            }
        });
    }

    public List<Product> GetProducts(string? genre = null, string? dev = null)
    {
        var query = _products.AsQueryable();
        if (!string.IsNullOrEmpty(genre)) query = query.Where(p => p.Attributes.Any(a => a.Value == genre));
        if (!string.IsNullOrEmpty(dev)) query = query.Where(p => p.Attributes.Any(a => a.Value == dev));
        return query.ToList();
    }
}