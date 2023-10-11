using System;
using System.Collections.Generic;
using System.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using AuthorizationApp.Models;

namespace AuthorizationApp.Services
{
    public class AuthService
    {
        private readonly string _secretKey = "superSecretKey";  // Klucz tajny, powinien być bezpieczny
        private readonly List<User> _users = new List<User>();  // Tu będziemy przechowywać użytkowników (tymczasowo)


        public string RegisterUser(string username, string password)
        {

            // Tutaj można dodać logikę walidacji i zapisu użytkownika do bazy danych

            // Tymczasowo dodajemy użytkownika do listy (bez walidacji hasła)
            var user = new User
            {
                Id = _users.Count + 1,
                Username = username,
                Password = password
            };

            _users.Add(user);

            // Generujemy token JWT
            var token = GenerateJwtToken(user.Id);

            return token;
        }

        private string GenerateJwtToken(int userId) 
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, userId.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(1), // Czas wygaśnięcia tokena (można dostosować)
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }
}
