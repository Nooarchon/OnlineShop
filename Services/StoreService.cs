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
        // --- GAMES ---
        AddProduct("Games", "Clair Obscur: Expedition 33", 59.99m, "RPG", "Sandfall Interactive", "2025", "https://tse2.mm.bing.net/th/id/OIP.-E-OBWki_2rpN12bCyAETgHaEK?rs=1&pid=ImgDetMain&o=7&rm=3");
        AddProduct("Games", "Silent Hill 2", 69.99m, "Horror", "Bloober Team", "2024", "https://shared.fastly.steamstatic.com/store_item_assets/steam/apps/2124490/header.jpg");
        AddProduct("Games", "GTA 5", 29.99m, "Action", "Rockstar Games", "2013", "https://shared.fastly.steamstatic.com/store_item_assets/steam/apps/271590/header.jpg");
        AddProduct("Games", "Kingdom Come: Deliverance", 69.99m, "RPG", "Warhorse Studios", "2018", "https://shared.fastly.steamstatic.com/store_item_assets/steam/apps/379430/header.jpg");
        AddProduct("Games", "Resident Evil", 29.99m, "Horror", "Capcom", "1996", "https://shared.fastly.steamstatic.com/store_item_assets/steam/apps/287290/header.jpg");
        AddProduct("Games", "Disco Elysium", 59.99m, "RPG", "ZA/UM", "2019", "https://shared.fastly.steamstatic.com/store_item_assets/steam/apps/632470/header.jpg");
        AddProduct("Games", "Dragon Age: Origins", 29.99m, "RPG", "BioWare", "2009", "https://shared.fastly.steamstatic.com/store_item_assets/steam/apps/17450/header.jpg");
        AddProduct("Games", "Manhunt", 49.99m, "Stealth", "Rockstar Games", "2003", "https://shared.fastly.steamstatic.com/store_item_assets/steam/apps/12130/header.jpg");
        AddProduct("Games", "Little Nightmares", 29.99m, "Horror", "Tarsier Studios", "2017", "https://shared.fastly.steamstatic.com/store_item_assets/steam/apps/424840/header.jpg");
        AddProduct("Games", "Wolf Among Us", 29.99m, "Adventure", "Telltale Games", "2013", "https://shared.fastly.steamstatic.com/store_item_assets/steam/apps/250320/header.jpg");
        AddProduct("Games", "The Walking Dead", 19.99m, "Adventure", "Telltale Games", "2012", "https://shared.fastly.steamstatic.com/store_item_assets/steam/apps/207610/header.jpg");
        AddProduct("Games", "Dispatch", 29.99m, "Interactive Movie", "Adhoc Studios", "2025", "https://tse1.mm.bing.net/th/id/OIP.LPlaagXuCcIGoefY4dt3xgHaEK?rs=1&pid=ImgDetMain&o=7&rm=3");
        AddProduct("Games", "Ghost of Tsushima", 49.99m, "Action", "Sucker Punch", "2020", "https://shared.fastly.steamstatic.com/store_item_assets/steam/apps/2215430/header.jpg");
        AddProduct("Games", "Ghost of Yotei", 29.99m, "Action", "Sucker Punch", "2025", "https://tse3.mm.bing.net/th/id/OIP.zzyQmSyACpY74uSpnGjTYgHaHa?rs=1&pid=ImgDetMain&o=7&rm=3");
        AddProduct("Games", "Life is Strange", 29.99m, "Adventure", "Dontnod", "2015", "https://shared.fastly.steamstatic.com/store_item_assets/steam/apps/319630/header.jpg");
        AddProduct("Games", "Heavy Rain", 29.99m, "Interactive Movie", "Quantic Dream", "2010", "https://shared.fastly.steamstatic.com/store_item_assets/steam/apps/960910/header.jpg");
        AddProduct("Games", "Detroit: Become Human", 29.99m, "Interactive Movie", "Quantic Dream", "2018", "https://tse2.mm.bing.net/th/id/OIP.22cm2fDjUn-GvG1TEMnBJQHaEK?rs=1&pid=ImgDetMain&o=7&rm=3");
        AddProduct("Games", "Until Dawn", 59.99m, "Horror", "Supermassive Games", "2015", "https://shared.fastly.steamstatic.com/store_item_assets/steam/apps/2172010/header.jpg");
        AddProduct("Games", "Devil May Cry", 49.99m, "Action", "Capcom", "2001", "https://shared.fastly.steamstatic.com/store_item_assets/steam/apps/631510/header.jpg");
        AddProduct("Games", "Death Stranding", 29.99m, "Action", "Kojima Productions", "2019", "https://shared.fastly.steamstatic.com/store_item_assets/steam/apps/1850570/header.jpg");
        AddProduct("Games", "Metal Gear", 29.99m, "Stealth", "Konami", "1987", "https://shared.fastly.steamstatic.com/store_item_assets/steam/apps/2131630/header.jpg");
        AddProduct("Games", "Reanimal", 29.99m, "Horror", "Tarsier Studios", "2026", "https://shared.fastly.steamstatic.com/store_item_assets/steam/apps/2129530/29ada835c47d05899c13a40062cabc127fcef005/ss_29ada835c47d05899c13a40062cabc127fcef005.1920x1080.jpg?t=1770997391");
        AddProduct("Games", "Mafia: City of Lost Heaven", 49.99m, "Action", "2K Czech", "2002", "https://shared.fastly.steamstatic.com/store_item_assets/steam/apps/40990/header.jpg");

        // --- MANGA / COMICS ---
        AddProduct("Comics", "Berserk", 14.99m, "Dark Fantasy", "Kentaro Miura", "1989", "https://tse2.mm.bing.net/th/id/OIP.kfMK1cdVtGgXWNPf2gZjWwHaKf?rs=1&pid=ImgDetMain&o=7&rm=3");
        AddProduct("Comics", "Monster", 20.99m, "Thriller", "Naoki Urasawa", "1994", "https://th.bing.com/th/id/OIP.cjRE3yVo4agpRi4ZNI1yHgHaLH?o=7rm=3&rs=1&pid=ImgDetMain&o=7&rm=3");
        AddProduct("Comics", "The Boys", 34.99m, "Superhero", "Garth Ennis", "2006", "https://tse2.mm.bing.net/th/id/OIP.AHC_CjlgeIXQnh6MyzZw7wHaLW?rs=1&pid=ImgDetMain&o=7&rm=3");
        AddProduct("Comics", "V for Vendetta", 54.99m, "Dystopia", "Alan Moore", "1982", "https://th.bing.com/th/id/R.05d59c75de124f7f46666aa1b9ab2b3e?rik=8W8Bpwt%2f893Gqw&pid=ImgRaw&r=0");
        AddProduct("Comics", "Watchmen", 16.99m, "Superhero", "Alan Moore", "1986", "https://tse4.mm.bing.net/th/id/OIP.-41OzqrHxapIZm3hCmhueQHaLe?rs=1&pid=ImgDetMain&o=7&rm=3");

        // --- MOVIES ---
        AddProduct("Movies", "Inception", 18.99m, "Sci-Fi", "Christopher Nolan", "2010", "https://m.media-amazon.com/images/I/912AErFSBHL._AC_SL1500_.jpg");
        AddProduct("Movies", "Fountain", 35.00m, "Drama", "Darren Aronofsky", "2001", "https://pics.filmaffinity.com/the_fountain-931937340-large.jpg");
        AddProduct("Movies", "Gone Girl", 20.00m, "Thriller", "David Fincher", "2014", "https://4.bp.blogspot.com/-Wh_SpCZzG_4/XFhvu4aVK-I/AAAAAAAAsVE/i1JeWliYSMA-U9lLfQJRQ-TCXEoX1a4RQCEwYBhgL/s1600/gone-girl.jpg");

        // --- TV SERIES ---
        AddProduct("TVSeries", "The Boys", 50.00m, "Satire", "Eric Kripke", "2019", "https://i.ytimg.com/vi/kfopABweE7Y/maxresdefault.jpg");
        AddProduct("TVSeries", "Sharp Objects", 60.00m, "Thriller", "Marti Noxon", "2018", "https://is1-ssl.mzstatic.com/image/thumb/Video114/v4/cd/05/5b/cd055bd0-6a7d-6e10-df5c-2ea9b6887280/796597_3740267_SharpObjects_S1_L2_3840x2160.lsr/1200x675.jpg");
        AddProduct("TVSeries", "Supernatural", 80.00m, "Fantasy", "Eric Kripke", "2005", "https://th.bing.com/th/id/R.d675110a960d9105592b3cfcf45503e7?rik=rKNNY5wyiZgKNQ&pid=ImgRaw&r=0");
        AddProduct("TVSeries", "Orphan Black", 30.00m, "Sci-Fi", "Graeme Manson", "2013", "https://artworks.thetvdb.com/banners/posters/260315-24.jpg");
        AddProduct("TVSeries", "Dark", 20.00m, "Sci-Fi", "Baran bo Odar", "2017", "https://m.media-amazon.com/images/M/MV5BM2RhZGVlZGItMGZiMy00YjdjLWIwMGUtMWYxOGIwNjA0MjNmXkEyXkFqcGc@._V1_FMjpg_UX1000_.jpg");
        AddProduct("TVSeries", "Severance", 40.00m, "Sci-Fi", "Dan Erickson", "2022", "https://m.media-amazon.com/images/M/MV5BZDI5YzJhODQtMzQyNy00YWNmLWIxMjUtNDBjNjA5YWRjMzExXkEyXkFqcGc@._V1_FMjpg_UX1000_.jpg");
        AddProduct("TVSeries", "Breaking Bad", 50.00m, "Crime", "Vince Gilligan", "2008", "https://th.bing.com/th/id/R.a0cce834143adc3f6ebc8e095183f2c7?rik=cQpDkBE5K%2bY4pg&pid=ImgRaw&r=0");
        AddProduct("TVSeries", "Plur1bus", 50.00m, "Sci-Fi", "Vince Gilligan", "2025", "https://news.northeastern.edu/wp-content/uploads/2025/07/Pluribus_1400.jpg");

        // --- MUSIC (RAMMSTEIN) ---
        AddProduct("Music", "Herzeleid", 19.99m, "Neue Deutsche Härte", "Rammstein", "1995", "https://tse1.mm.bing.net/th/id/OIP._tPG5B2aS56Q5swOruLz8AHaD4?rs=1&pid=ImgDetMain&o=7&rm=3");
        AddProduct("Music", "Sehnsucht", 21.50m, "Neue Deutsche Härte", "Rammstein", "1997", "https://tse2.mm.bing.net/th/id/OIP.ziJgOg748ZwYxsURuoEm3gHaHY?w=600&h=598&rs=1&pid=ImgDetMain&o=7&rm=3");
        AddProduct("Music", "Mutter", 25.00m, "Neue Deutsche Härte", "Rammstein", "2001", "https://img.discogs.com/h2uuMlMjSN_VJDEyxKiew-ntQSk=/fit-in/600x658/filters:strip_icc():format(jpeg):mode_rgb():quality(90)/discogs-images/R-527643-1482255823-7617.jpeg.jpg");
        AddProduct("Music", "Reise, Reise", 22.99m, "Neue Deutsche Härte", "Rammstein", "2004", "https://th.bing.com/th/id/OIP.NyA0r3dMAhCJQbW4YTMJNgHaGm?o=7rm=3&rs=1&pid=ImgDetMain&o=7&rm=3");
        AddProduct("Music", "Rosenrot", 22.00m, "Neue Deutsche Härte", "Rammstein", "2005", "https://th.bing.com/th/id/R.d9f5494951cb4c660a87a02fdcd11c69?rik=JfW%2bMxrW1IdvJQ&pid=ImgRaw&r=0");
        AddProduct("Music", "Liebe ist für alle da", 26.50m, "Neue Deutsche Härte", "Rammstein", "2009", "https://tse4.mm.bing.net/th/id/OIP.bq0PGuJl5pYAr0IXFtYWSQHaEp?rs=1&pid=ImgDetMain&o=7&rm=3");
        AddProduct("Music", "Rammstein", 28.00m, "Neue Deutsche Härte", "Rammstein", "2019", "https://th.bing.com/th/id/R.676c85fcef1273d0fe919f89b8295f05?rik=gqrGjpznsvL0eA&pid=ImgRaw&r=0");
        AddProduct("Music", "Zeit", 29.99m, "Neue Deutsche Härte", "Rammstein", "2022", "https://tse1.mm.bing.net/th/id/OIP.BqLyJd8a4jHcH3wVUJPmJQHaHb?rs=1&pid=ImgDetMain&o=7&rm=3");
    }

    private void AddProduct(string category, string name, decimal price, string genre, string creator, string year, string imageUrl)
    {
        _products.Add(new Product
        {
            Id = Guid.NewGuid().ToString(),
            Name = name,
            Category = category,
            Price = price,
            ImageUrl = imageUrl, // Устанавливаем картинку
            Description = $"Experience {name}, a premier title in the {genre} genre.",
            Reviews = new List<Review>(),
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

    // Удаление отзыва
    public bool RemoveReview(string productId, string email)
    {
        var product = _products.FirstOrDefault(p => p.Id == productId);
        if (product == null) return false;

        var review = product.Reviews.FirstOrDefault(r => r.User == email);
        if (review == null) return false;

        product.Reviews.Remove(review);
        return true;
    }

    // Обновление отзыва (если отзыв уже есть — исправляем, если нет — создаем)
    public bool UpdateReview(string productId, string email, string comment, int rating)
    {
        var product = _products.FirstOrDefault(p => p.Id == productId);
        if (product == null) return false;

        var existingReview = product.Reviews.FirstOrDefault(r => r.User == email);

        if (existingReview != null)
        {
            // Исправляем старый
            existingReview.Comment = comment;
            existingReview.Rating = Math.Clamp(rating, 1, 5);
            existingReview.Date = DateTime.Now;
        }
        else
        {
            // Если вдруг вызвали Update для несуществующего — просто добавляем
            AddReview(productId, email, comment, rating);
        }
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