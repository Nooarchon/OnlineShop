using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.Models; 

using OnlineShop.Models;

namespace OnlineShop.Services
{
    public class AuthService
    {
        private readonly List<User> _users = new();

        public string Register(string email, string password)
        {
            if (_users.Any(u => u.Email == email))
                return "Error: Email already registered";

            _users.Add(new User
            {
                Id = Guid.NewGuid(), // Secure unique ID
                Email = email,
                Password = password
            });

            return "Success: User registered";
        }

        public User? Login(string email, string password)
        {
            return _users.FirstOrDefault(u => u.Email == email && u.Password == password);
        }
    }
}