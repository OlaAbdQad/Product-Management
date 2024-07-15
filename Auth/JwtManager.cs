using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Assessment_Task.Dtos;
using Microsoft.IdentityModel.Tokens;

namespace Assessment_Task.Auth
{
    public class JwtManager(string key) : IJwtManager
    {
        private readonly string _key = key;

        public string GenerateToken(UserDto user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenKey = Encoding.ASCII.GetBytes(_key);
            var claims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier, user.Name),
                new(ClaimTypes.Email, user.Email),
                new(ClaimTypes.Role, user.RoleName)

            };
        

            var tokenDescriptior = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                IssuedAt = DateTime.Now,
                Expires = DateTime.Now.AddHours(2),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptior);

            return tokenHandler.WriteToken(token);
        }

        
    }
}
