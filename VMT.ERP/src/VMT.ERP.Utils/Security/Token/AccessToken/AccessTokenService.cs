using VMT.ERP.Domain.Entities;
using VMT.ERP.Utils.Interfaces.Token.AccessToken;
using VMT.ERP.Utils.Interfaces.Token.Configuration;

namespace VMT.ERP.Utils.Security.Token.AccessToken
{
    public class AccessTokenService(ITokenConfigurationService _service) : IAccessTokenService
    {
        private readonly ITokenConfigurationService service = _service;

        public string GenerateToken(Usuario usuario)
        {
            var Claims = service.GetClaims(usuario);

            var Key = service.GetSecurityKey();

            var Credentials = service.GetSigningCredentials(Key);

            var SecurityToken = service.BuildSecurityToken(Claims, Credentials);

            var Token = service.WriteToken(SecurityToken);

            return Token;
        }
    }
}