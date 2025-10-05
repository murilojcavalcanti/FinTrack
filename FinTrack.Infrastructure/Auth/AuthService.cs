using FinTrack.Core.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FinTrack.Infrastructure.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _config;

        public AuthService(IConfiguration config)
        {
            _config = config;
        }
        public string GenerateToken(string Email, int Id, string Role)
        {
            var Key = _config["Jwt:Key"];
            var Issuer = _config["Jwt:Issuer"];
            var Audicence = _config["Jwt:Audicence"];
            var SymmetricKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key));
            var credentials = new SigningCredentials(SymmetricKey,SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>
            {
                new Claim("UserName",Email),
                new Claim(ClaimTypes.NameIdentifier, $"{Id}"),
                new Claim(ClaimTypes.Role,Role)
            };

            var tokenST = new JwtSecurityToken(Issuer,Audicence,claims,null,DateTime.Now.AddHours(5),credentials);
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.WriteToken(tokenST);
            return token;
        }

        public string ComputeHash(string password)
        {
            using (SHA256 hash = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = hash.ComputeHash(bytes);
                StringBuilder builder = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    builder.Append(b.ToString("X2"));
                }
                return builder.ToString();
            }
        }

        public List<Claim> GetUserClaimsLoged(HttpContext httpContext)
        {
            return httpContext.User.Claims.ToList();       
        }
    }
}
