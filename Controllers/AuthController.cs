using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Models;
using OnlineShop.Services;
using OnlineShop.Controllers;
using System.Runtime.InteropServices;

namespace OnlineShop.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        // Visual Studio automataclly put AuthService from Program.cs
        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("signup")]
        public IActionResult SignUp([FromBody] UserAuthDto data)
        {
            var result = _authService.Register(data.Email, data.Password);
            if (result.StartsWith("Error")) return BadRequest(new { message = result });
            return Ok(new { message = result });
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserAuthDto data)
        {
            var user = _authService.Login(data.Email, data.Password);
            if (user == null) return Unauthorized(new { message = "Incorrect login or password" });
            return Ok(new { email = user.Email });
        }
    }

    //Helper class for receiving data from a website
    public class UserAuthDto
    {
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";
    }
}