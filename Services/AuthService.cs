using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.Models; // PLEASE ADD THIS LINE

namespace OnlineShop.Services
{
    public class AuthService
    {
        private readonly List<User> _users = new();
        private const int MaxUsers = 10;

        public string Register(string email, string password)
        {
            if (_users.Count >= MaxUsers) return "Error: Limit 10 users";

            // Simple password complexity validation
            if (password.Length < 8) return "Error: Password must be at least 8 characters";

            _users.Add(new User { Id = _users.Count + 1, Email = email, Password = password });
            return "Success";
        }

        public User? Login(string email, string password)
        {
            return _users.FirstOrDefault(u => u.Email == email && u.Password == password);
        }
    }
}