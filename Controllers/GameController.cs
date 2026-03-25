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
    [Route("api")] // We set the base to 'api'
    public class GameController : ControllerBase
    {
        private readonly StoreService _storeService;

        public GameController(StoreService storeService)
        {
            _storeService = storeService;
        }

        // 1. GET: api/games (This populates your catalog)
        [HttpGet("games")]
        public IActionResult GetProducts(
            [FromQuery] string? category,
            [FromQuery] string[]? genres,
            [FromQuery] string[]? creators,
            [FromQuery] string[]? years)
        {
            var products = _storeService.GetFacetProducts(category, genres, creators, years);
            return Ok(products);
        }

        // 2. GET: api/products/{id} (This shows the details modal)
        [HttpGet("products/{id}")]
        public IActionResult GetProduct(string id)
        {
            // Use GetFacetProducts with no filters to search the full list
            var product = _storeService.GetFacetProducts()
                                       .FirstOrDefault(p => p.Id == id);

            if (product == null) return NotFound(new { message = "Game not found" });

            return Ok(product);
        }

        // 3. POST: api/products/review (This saves reviews)
        [HttpPost("products/review")]
        public IActionResult AddReview([FromBody] ReviewDto data)
        {
            if (data == null || string.IsNullOrEmpty(data.ProductId)) return BadRequest("Invalid data");

            // Ensure the service actually finds the product and adds the review
            var success = _storeService.AddReview(data.ProductId, data.UserEmail, data.Comment, data.Rating);

            if (success) return Ok(new { message = "Review added" });
            return BadRequest(new { message = "Failed to add review. Check if ProductId is correct." });
        }
        // 4. PUT: api/products/review (Updates an existing review)
        [HttpPut("products/review")]
        public IActionResult UpdateReview([FromBody] ReviewDto data)
        {
            // StoreService.UpdateReview handles finding the review by email
            var success = _storeService.UpdateReview(data.ProductId, data.UserEmail, data.Comment, data.Rating);
            return success ? Ok(new { message = "Review updated" }) : BadRequest();
        }

        // 5. DELETE: api/products/review (Removes a review)
        [HttpDelete("products/review")]
        public IActionResult DeleteReview([FromQuery] string productId, [FromQuery] string email)
        {
            var success = _storeService.RemoveReview(productId, email);
            return success ? Ok(new { message = "Review deleted" }) : NotFound();
        }
    }

    public class ReviewDto
    {
        public string ProductId { get; set; } = "";
        public string UserEmail { get; set; } = "";
        public string Comment { get; set; } = "";
        public int Rating { get; set; }
    }
}