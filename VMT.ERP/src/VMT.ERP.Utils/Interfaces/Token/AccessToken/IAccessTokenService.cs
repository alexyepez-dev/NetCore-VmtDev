using VMT.ERP.Domain.Entities;

namespace VMT.ERP.Utils.Interfaces.Token.AccessToken
{
    public interface IAccessTokenService
    {
        string GenerateToken(Usuario usuario);
    }
}