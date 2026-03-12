using Microsoft.AspNetCore.Mvc;
using OnlineShop.Services;
using OnlineShop.Models;

namespace OnlineShop.Controllers
{
    [ApiController]
    [Route("api/cart")]
    public class CartController : ControllerBase
    {
        private readonly CartService _cartService;
        private readonly StoreService _storeService;

        public CartController(CartService cartService, StoreService storeService)
        {
            _cartService = cartService;
            _storeService = storeService;
        }

        [HttpPost("add")]
        public IActionResult Add([FromBody] AddToCartDto data)
        {
            // Fix: Pass 4 nulls to match the StoreService.GetFacetProducts signature
            var product = _storeService.GetFacetProducts(null, null, null, null)
                                       .FirstOrDefault(p => p.Id == data.ProductId);

            if (product == null)
                return NotFound(new { message = "Product not found" });

            var result = _cartService.AddToCart(data.UserEmail, product);

            if (result.StartsWith("Error"))
                return BadRequest(new { message = result });

            return Ok(new { message = result });
        }

        [HttpGet("{email}")]
        public IActionResult GetCart(string email)
        {
            var cart = _cartService.GetCart(email);
            return Ok(cart);
        }

        // FIX: Changed from HttpPost to HttpDelete to match the frontend fetch method
        [HttpDelete("remove")]
        public IActionResult Remove([FromBody] AddToCartDto data)
        {
            _cartService.RemoveFromCart(data.UserEmail, data.ProductId);
            return Ok(new { message = "Removed" });
        }

        [HttpDelete("clear/{email}")]
        public IActionResult Clear(string email)
        {
            _cartService.ClearCart(email);
            return Ok(new { message = "Order placed successfully!" });
        }
    }

    public class AddToCartDto
    {
        public string UserEmail { get; set; } = "";
        public string ProductId { get; set; } = "";
    }
}