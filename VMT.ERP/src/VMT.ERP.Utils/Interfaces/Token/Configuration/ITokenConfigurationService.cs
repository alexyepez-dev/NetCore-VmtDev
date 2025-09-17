using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using VMT.ERP.Domain.Entities;

namespace VMT.ERP.Utils.Interfaces.Token.Configuration
{
    public interface ITokenConfigurationService
    {
        IEnumerable<Claim> GetClaims(Usuario usuario);
        SymmetricSecurityKey GetSecurityKey();
        SigningCredentials GetSigningCredentials(SymmetricSecurityKey key);
        JwtSecurityToken BuildSecurityToken(IEnumerable<Claim> claims, SigningCredentials credentials);
        string WriteToken(JwtSecurityToken token);
    }
}