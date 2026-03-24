using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions; 
using OnlineShop.Models;

namespace OnlineShop.Services
{
    public class AuthService
    {
        private readonly List<User> _users = new();

        public string Register(string email, string password)
        {
            // 1. Email Check
            if (!IsValidEmail(email))
                return "Error: Invalid email format.";

            // 2. Password Check
            var passwordCheck = IsPasswordSecure(password);
            if (passwordCheck != "OK")
                return $"Error: {passwordCheck}";

            // 3. Duplicate Check
            if (_users.Any(u => u.Email == email))
                return "Error: Email already registered.";

            _users.Add(new User
            {
                Id = Guid.NewGuid(),
                Email = email,
                Password = password 
            });

            return "Success: User registered";
        }

        public User? Login(string email, string password)
        {
            return _users.FirstOrDefault(u => u.Email == email && u.Password == password);
        }

        // Email Validation
        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;

            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }

        // Password Validation
        private string IsPasswordSecure(string password)
        {
            if (string.IsNullOrWhiteSpace(password)) return "Password cannot be empty.";
            if (password.Length < 8) return "Password must be at least 8 characters long.";
            if (!password.Any(char.IsUpper)) return "Password must contain at least one uppercase letter.";
            if (!password.Any(char.IsLower)) return "Password must contain at least one lowercase letter.";
            if (!password.Any(char.IsDigit)) return "Password must contain at least one digit.";

            return "OK";
        }
    }
}