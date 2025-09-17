using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using VMT.ERP.Domain.Entities;
using VMT.ERP.Utils.Interfaces.Token.Configuration;
using VMT.ERP.Utils.Security.Models.Jwt;

namespace VMT.ERP.Utils.Security.Token.Configuration
{
    public class TokenConfigurationService(IOptions<JwtSettings> _settings) : ITokenConfigurationService
    {
        private readonly JwtSettings settings = _settings.Value;

        public IEnumerable<Claim> GetClaims(Usuario usuario)
            => [
                new("username", usuario.UsuNombre!) 
               ];

        public SymmetricSecurityKey GetSecurityKey()
        {
            var key = settings.Key;
            var encoding = Encoding.UTF8.GetBytes(key);

            return new(encoding);
        }

        public SigningCredentials GetSigningCredentials(SymmetricSecurityKey key)
        {
            var algorith = SecurityAlgorithms.HmacSha256Signature;

            return new(key, algorith);
        }

        public JwtSecurityToken BuildSecurityToken(IEnumerable<Claim> claims, SigningCredentials credentials)
        {
            var issuer = settings.Issuer;
            var audience = settings.Audience;
            var value = settings.Expiration;
            var expires = DateTime.UtcNow.AddYears(value);

            return new(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: expires,
                signingCredentials: credentials
            );
        }

        public string WriteToken(JwtSecurityToken token)
            => new JwtSecurityTokenHandler().WriteToken(token);
    }
}