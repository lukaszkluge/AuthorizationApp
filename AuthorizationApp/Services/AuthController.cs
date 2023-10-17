using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorizationApp.Services
{
    public class AuthController
    {
        private readonly AuthService _authService;
        public AuthController()
        {
            _authService = new AuthService();
        }

        public void RegisterAndAuthenticate()
        {
            // User registration and authorization simulation
            Console.Write("Enter your username:");
            var username = Console.ReadLine();

            Console.Write("Enter your password:");
            var password = Console.ReadLine();

            // user registration 
            var token = _authService.RegisterUser(username, password);

            Console.WriteLine("User registered and JWT generated:");
            Console.WriteLine(token);

            // In a real project, the token should be saved and passed to the API in headers
        }

        public void CheckAuthorization()
        {
            Console.WriteLine("Enter JWT token:");
            var token = Console.ReadLine();

            bool isAuthenticated = _authService.AuthenticateUser(token);

            if (isAuthenticated)
            {
                Console.WriteLine("User is authorized.");
            }
            else
            {
                Console.WriteLine("User is not authorized.");
            }
        }

    }
}

