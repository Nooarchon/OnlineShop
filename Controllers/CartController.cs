using Microsoft.AspNetCore.Mvc;
using OnlineShop.Services;

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
            // 1. Ищем товар, передавая null во все фильтры, чтобы получить полный список
            var product = _storeService.GetFacetProducts(null, null, null)
                                       .FirstOrDefault(p => p.Id == data.ProductId);

            if (product == null)
                return NotFound(new { message = "Product not found" });

            // 2. Добавляем в корзину и получаем результат
            var result = _cartService.AddToCart(data.UserEmail, product);

            // 3. Проверяем на ошибки (например, лимит в 10 товаров)
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

        [HttpPost("remove")]
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