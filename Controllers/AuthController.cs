using System;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Services;
using OnlineShop.Models;
using System.ComponentModel.DataAnnotations; // Нужно для [Required] и [EmailAddress]

namespace OnlineShop.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        // Изменил путь на "register", чтобы соответствовать логике JS или оставил signup
        [HttpPost("register")]
        public IActionResult SignUp([FromBody] UserAuthDto data)
        {
            // ModelState проверит аннотации из UserAuthDto автоматически
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Invalid data format" });
            }

            var result = _authService.Register(data.Email, data.Password);

            if (result.StartsWith("Error"))
                return BadRequest(new { message = result });

            return Ok(new { message = result });
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserAuthDto data)
        {
            var user = _authService.Login(data.Email, data.Password);
            if (user == null)
                return Unauthorized(new { message = "Error: Invalid login or password" });

            return Ok(new { email = user.Email, id = user.Id });
        }
    }

    public class UserAuthDto
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; } = "";

        [Required(ErrorMessage = "Password is required")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters")]
        public string Password { get; set; } = "";
    }
}