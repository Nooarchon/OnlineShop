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
        // Fill the catalog according to your specifications 
        AddGame("Clair Obscur", "RPG", "Sandfall Interactive");
        AddGame("Kingdom Come: Deliverance", "RPG", "Warhorse Studios");
        AddGame("Silent Hill", "Horror", "Konami");
        AddGame("Resident Evil", "Horror", "Capcom");
        AddGame("Disco Elysium", "RPG", "ZA/UM");
        AddGame("Dragon Age", "RPG", "BioWare");
        AddGame("GTA 5", "Action", "Rockstar Games");
        AddGame("Manhunt", "Stealth", "Rockstar Games");
        AddGame("Little Nightmares", "Horror/Quest", "Tarsier Studios");
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
            // USING Guid for uniqueness (instead of Count + 1)
            Id = Guid.NewGuid().ToString(),
            Name = name,
            Price = 59.99m,
            Attributes = new() {
new ProductAttr("Genre", genre),
new ProductAttr("Developer", dev)
}
        });
    }

    // FACETED FILTER: allows you to pass multiple values ​​at once
    public List<Product> GetFacetProducts(string[]? genres = null, string[]? devs = null)
    {
        var query = _products.AsQueryable();

        if (genres != null && genres.Length > 0)
        {
            // Find products with the "Genre" attribute value in the selected list
            query = query.Where(p => p.Attributes.Any(a => a.Name == "Genre" && genres.Contains(a.Value)));
        }

        if (devs != null && devs.Length > 0)
        {
            query = query.Where(p => p.Attributes.Any(a => a.Name == "Developer" && devs.Contains(a.Value)));
        }

        return query.ToList();
    }
}