using Microsoft.Extensions.Configuration;
using VMT.ERP.Utils.Helpers.Api;
using VMT.ERP.Utils.Helpers.Message;
using VMT.ERP.Utils.Interfaces.Password;
using VMT.ERP.Utils.Security.Models.Encrypt;

namespace VMT.ERP.Utils.Security.Password
{
    public class PasswordHelper(IConfiguration _configuration) : IPasswordHelper
    {
        private readonly IConfiguration configuration = _configuration;

        public DataEncrypt GetDataEncrypt()
        {
            try
            {
                var section = DataEncrypt.EncrypDataSection;
                var encryptDataSection = configuration.GetSection(section);

                var encryptKey = encryptDataSection["Key"];
                var expressionToValidateKey = string.IsNullOrEmpty(encryptKey);

                if (expressionToValidateKey)
                {
                    throw new InvalidOperationException("La clave de encriptación 'Key' no se encontró en la sección 'EncrypData' de la configuración.");
                }

                return new DataEncrypt(encryptKey!);
            }
            catch (Exception error)
            {
                var contextMessageInternalError = ResponseStatusCode.InternalErrorMessage;

                return new DataEncrypt($"Error: {error} | Unexpected error: {contextMessageInternalError}");
            }
        }

        public string EncryptDataMethod(string text)
        {
            try
            {
                var encrypData = GetDataEncrypt();

                return "";
            }
            catch (Exception error)
            {
                var contextMessageInternalError = ResponseStatusCode.InternalErrorMessage;

                return $"Error: {error} | Unexpected error: {contextMessageInternalError}";
            }
        }
    }
}