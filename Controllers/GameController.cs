using Microsoft.AspNetCore.Mvc;
using OnlineShop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Controllers
{
    [ApiController]
    [Route("api/games")]
    public class GameController : ControllerBase
    {
        private readonly StoreService _storeService;

        public GameController(StoreService storeService)
        {
            _storeService = storeService;
        }

        [HttpGet]
        public IActionResult GetProducts(
            [FromQuery] string? category,
            [FromQuery] string[]? genres,
            [FromQuery] string[]? creators,
            [FromQuery] string[]? years)
        {
            // Исправлено имя метода на GetFacetProducts (как в твоем StoreService)
            var products = _storeService.GetFacetProducts(category, genres, creators, years);
            return Ok(products);
        }
    }
}