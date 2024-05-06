using FamilyCalendar.Calendar.Application.Interfaces;
using FamilyCalendar.Calendar.Application.Services;
using FamilyCalendar.Calendar.Core.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FamilyCalendar.Infrastructure
{
    public class JwtProvider : IJwtProvider
    {
        private readonly JwtOptions _jwtOptions;
  
        public JwtProvider(JwtOptions options)
        {
            _jwtOptions = options;

        }
        public string GenerateToken(User user)
        {
            // Установка Microsoft.AspNetCore.Authentication.JwtBearer
            // Секретный ключ надо хранить где то в секретном месте (но пока он полежит в appsettings.json)

            Claim[] claims = [new("userId", user.UserID.ToString())];

            var MySigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SecretKey)),
                SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                signingCredentials: MySigningCredentials,
                expires: DateTime.UtcNow.AddHours(_jwtOptions.ExpitesHours));

            var tokenValue = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenValue;
        }
    }
}
