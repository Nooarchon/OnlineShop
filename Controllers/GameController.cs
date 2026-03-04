using Microsoft.AspNetCore.Mvc;
using OnlineShop.Services;
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
        public IActionResult GetGames([FromQuery] string[]? genres, [FromQuery] string[]? devs)
        {
            // Use the updated method from StoreService
            var games = _storeService.GetFacetProducts(genres, devs);
            return Ok(games);
        }
    }
}