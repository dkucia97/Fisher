using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Fisher.Core.Data.Dtos;
using Fisher.Core.Utilities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Fisher.Infrastructure.Auth
{
    public class JwtHandler:IJwtHandler
    {
        private JwtSettings _settings;

        public JwtHandler(IOptions<JwtSettings> settings)
        {
            _settings = settings.Value;
        }
        
        public JwtDto GetToken(string userName, string role)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var claims = new Claim[]
            {
                new Claim(ClaimTypes.Name, userName),
                new Claim(ClaimTypes.Role, role),
            };
            var expire = DateTime.Now.AddMinutes(_settings.ExpireTime);
            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.Key)),
                SecurityAlgorithms.HmacSha256Signature );
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                SigningCredentials = signingCredentials,
                Issuer = _settings.Issuer,
                Expires = expire
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new JwtDto()
            {
                Expires = _settings.ExpireTime,
                Token = tokenHandler.WriteToken(token)
            };

        }
    }
}