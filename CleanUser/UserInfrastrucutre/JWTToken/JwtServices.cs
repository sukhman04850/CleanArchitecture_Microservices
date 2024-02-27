using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace UserInfrastrucutre.JWTToken
{
    public class JwtServices
    {
        public string SecretKey { get; set; }
        public int TokenDuration { get; set; }
        private readonly IConfiguration config;


        public JwtServices(IConfiguration _config)
        {


            config = _config;
            var jwtConfigSection = config.GetSection("jwtConfig");
            this.SecretKey = jwtConfigSection.GetSection("Key").Value;
            this.TokenDuration = Int32.Parse(jwtConfigSection.GetSection("Duration").Value);
        }
        public string GenerateToken(Guid Id, String Email, String Role)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.SecretKey));
            var signature = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var payload = new[]
            {
                new Claim("id",Id.ToString()),
                new Claim("Role", Role),
                new Claim("Email", Email),

            };
            var jwtToken = new JwtSecurityToken(
                issuer: "localhost",
                audience: "localhost",
                claims: payload,
                expires: DateTime.Now.AddMinutes(TokenDuration),
                signingCredentials: signature
                );
            return new JwtSecurityTokenHandler().WriteToken(jwtToken);
        }
    }
}
