using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BankingControlPanel.API.Services.JWT
{
    public class JwtManager :IJwtManager
    {
        private readonly string _secret;
        private readonly double _expireMinutes;
        public JwtManager(IConfiguration config)
        {
            _secret = config["JwtConfig:Key"];            
            _expireMinutes = double.Parse(config["JwtConfig:ExpireMinutes"]);
        }
        public string GenerateToken(IEnumerable<Claim> claims)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(_expireMinutes),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
