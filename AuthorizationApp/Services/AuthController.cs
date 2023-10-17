using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorizationApp.Services
{
    public class AuthController()
    {
        _authService = new AuthService();     // authorization service initialization
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

}
