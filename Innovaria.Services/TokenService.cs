using Innovaria.COMMON.Entities;
using Innovaria.COMMON.Interfaces;

using Microsoft.Extensions.Configuration;

using Microsoft.IdentityModel.Tokens;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Innovaria.Services
{
    public class TokenService : ITokenService
    {
        private IConfiguration _config;
        private readonly SymmetricSecurityKey _securityKey;

        public TokenService(IConfiguration config)
        {
            this._config = config;
            _securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));
        }

        public string CreateToken(User userLogin)
        {
            var claims = new List<Claim>
            {
                new Claim("UserName",userLogin.UserName),
                new Claim("PKUser",""+userLogin.PkUser),
            };
            var creds = new SigningCredentials(_securityKey, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddHours(7),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
