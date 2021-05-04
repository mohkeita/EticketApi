using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Eticket.Dal.Entities;
using Microsoft.IdentityModel.Tokens;

namespace Eticket.Api.TokenJWT
{
    public class TokenManager
    {
        public static string secret = "g7NW26tGT7z1Gn3361fCBclc2txCw6kQqZACf7WJEfT8D3qFMDHm4pZ/URboHIh9Y9o7OCR181sF3WDrDcPnDgxDYsKRMY521UEq/zisatT9IxZ4p2VeJWDmQrP4movASSYO4bgGLd2TClCyjCzaJN7c/nwLjWsxlNnfKI/vtfw=";
        public static string issuer = "mohkeita.io";
        public static string audience = "mohkeita.io";
        
        public string GenerateJWT(UserApp user)
        {
            if (user.Email is null)
                throw new ArgumentException();

            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);

            Claim[] claims = new[]
            {
                new Claim("UserId", user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, (user.IsAdmin ? "admin" : "user"))
            };

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials
            );

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }
    }
}