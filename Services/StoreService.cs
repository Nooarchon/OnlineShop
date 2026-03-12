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
        // --- ИГРЫ ---
        AddProduct("Games", "Clair Obscur", 59.99m, "RPG", "Sandfall Interactive", "2025");
        AddProduct("Games", "Silent Hill 2", 69.99m, "Horror", "Bloober Team", "2024");
        AddProduct("Games", "GTA 5", 29.99m, "Action", "Rockstar Games", "2013");
        AddProduct("Games", "Kingdom Come: Deliverance", 69.99m, "RPG", "Warhorse Studios", "2018");
        AddProduct("Games", "Resident Evil", 29.99m, "Horror", "Capcom", "1996");
        AddProduct("Games", "Disco Elysium", 59.99m, "RPG", "ZA/UM", "2019");
        AddProduct("Games", "Dragon Age", 29.99m, "RPG", "BioWare", "2009");
        AddProduct("Games", "Manhunt", 49.99m, "Stealth", "Rockstar Games", "2003");
        AddProduct("Games", "Little Nightmares", 29.99m, "Horror/Quest", "Tarsier Studios", "2017");
        AddProduct("Games", "Wolf Among Us", 29.99m, "Adventure", "Telltale Games", "2013");
        AddProduct("Games", "Walking dead", 19.99m, "Adventure", "Telltale Games", "2012");
        AddProduct("Games", "Dispatch", 29.99m, "Interactive Movie", "Adhoc studious", "2025");
        AddProduct("Games", "Ghost of Tsushima", 49.99m, "Action", "Sucker Punch", "2020");
        AddProduct("Games", "Ghost of Yotei", 29.99m, "Action", "Sucker Punch", "2025");
        AddProduct("Games", "Life is Strange", 29.99m, "Adventure", "Dontnod", "2015");
        AddProduct("Games", "Heavy Rain", 29.99m, "Interactive Movie", "Quantic Dream", "2010");
        AddProduct("Games", "Detroit: Become Human", 29.99m, "Interactive Movie", "Quantic Dream", "2018");
        AddProduct("Games", "Until Dawn", 59.99m, "Horror", "Supermassive Games", "2015");
        AddProduct("Games", "Devil May Cry", 49.99m, "Action", "Capcom", "2001");
        AddProduct("Games", "Death Stranding", 29.99m, "Action", "Kojima Productions", "2019");
        AddProduct("Games","Metal Gear", 29.99m, "Stealth", "Konami", "1987");
        AddProduct("Games", "Reanimal", 29.99m, "Horror", "Tarsier Studios", "2026");
        AddProduct("Games", "Mafia", 49.99m, "Action", "2K Czech", "2002");


        // --- МАНГА / КОМИКСЫ ---
        AddProduct("Comics", "Berserk Vol. 1", 14.99m, "Dark Fantasy", "Kentaro Miura", "1989");
        AddProduct("Comics", "Monster Vol. 1", 14.99m, "Thriller", "Naoki Urasawa", "1994");
        AddProduct("Comics", "Batman: Year One", 19.99m, "Detective", "Frank Miller", "1987");
        AddProduct("Comics", "The Boys Vol. 1", 14.99m, "Superhero", "Garth Ennis, Darick Robertson", "2006");
        AddProduct("Comics", "V for Vendetta Vol. 1", 14.99m, "Dystopia", "Alan Moore", "1982");
        AddProduct("Comics", "Watchmen Vol. 1", 16.99m, "Superhero", "Alan Moore", "1986");

        // --- ФИЛЬМЫ / СЕРИАЛЫ ---
        AddProduct("Movies", "Inception", 12.99m, "Sci-Fi", "Christopher Nolan", "2010");
        AddProduct("Movies", "Requim for dream", 10.00m, "Drama", "Darren Arnofsky", "2001");

        //TVSeries
        AddProduct("TVSeries", "The Boys", 50.00m, "Satire", "Eric Kripke", "2019");
        AddProduct("TVSeries", "Supernatural", 80.00m, "Fantasy", "Eric Kripke", "2005");
        AddProduct("TVSeries", "Orphan Black", 30.00m, "Sci-Fi", "Graeme Manson", "2013");
        AddProduct("TVSeries", "Dark", 20.00m, "Sci-Fi", "Baran bo Odar and Jantje Friese", "2017");


        // --- МУЗЫКА ---
        AddProduct("Music", "Mutter", 25.00m, "Neue Deutsche Härte", "Rammstein", "2001");
    }

    private void AddProduct(string category, string name, decimal price, string genre, string creator, string year)
    {
        _products.Add(new Product
        {
            Id = Guid.NewGuid().ToString(),
            Name = name,
            Category = category,
            Price = price,
            Description = $"Experience {name}, a premier title in the {genre} genre.", // Added description
            Reviews = new List<Review>(), // CRITICAL: Initialize this so the list isn't null!
            Attributes = new()
            {
                new ProductAttr("Genre", genre),
                new ProductAttr("Creator", creator),
                new ProductAttr("Year", year)
            }
        });
    }

    public bool AddReview(string productId, string email, string comment, int rating)
    {
        var product = _products.FirstOrDefault(p => p.Id == productId);
        if (product == null) return false;

        product.Reviews.Add(new Review
        {
            User = email,
            Comment = comment,
            Rating = Math.Clamp(rating, 1, 5),
            Date = DateTime.Now
        });
        return true;
    }

    public List<Product> GetFacetProducts(
        string? category = null,
        string[]? genres = null,
        string[]? creators = null,
        string[]? years = null)
    {
        var query = _products.AsQueryable();

        if (!string.IsNullOrEmpty(category))
            query = query.Where(p => p.Category == category);

        if (genres != null && genres.Length > 0)
            query = query.Where(p => p.Attributes.Any(a => a.Name == "Genre" && genres.Contains(a.Value)));

        // FIXED: Corrected the creator filter logic
        if (creators != null && creators.Length > 0)
            query = query.Where(p => p.Attributes.Any(a =>
                (a.Name == "Creator" || a.Name == "Developer") && creators.Contains(a.Value)));

        if (years != null && years.Length > 0)
            query = query.Where(p => p.Attributes.Any(a => a.Name == "Year" && years.Contains(a.Value)));

        return query.ToList();
    }
}