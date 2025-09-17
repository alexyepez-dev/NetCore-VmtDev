using Microsoft.Extensions.Configuration;
using VMT.ERP.Utils.Encryption;
using VMT.ERP.Utils.GetResponse;
using VMT.ERP.Utils.Guards;
using VMT.ERP.Utils.Helpers.Api;
using VMT.ERP.Utils.Helpers.Message;
using VMT.ERP.Utils.Interfaces.Password;
using VMT.ERP.Utils.Security.Models.Encrypt;

namespace VMT.ERP.Utils.Security.Password
{
    public class PasswordHelper(IConfiguration _configuration) : IPasswordHelper
    {
        private readonly IConfiguration configuration = _configuration;

        public ApiResponse<DataEncrypt> GetDataEncrypt()
        {
            try
            {
                var section = DataEncrypt.EncrypDataSection;
                var encryptDataSection = configuration.GetSection(section);

                var keySection = DataEncrypt.KeyConfigSection;
                var keyConfigMessage = DataEncrypt.KeyConfigMessage;
                var encryptKey = encryptDataSection[keySection];
                Guard.NotNullOrEmpty(encryptKey, keyConfigMessage);

                var ivSection = DataEncrypt.IvConfigSection;
                var ivConfigMessage = DataEncrypt.IvConfigMessage;
                var encryptIv = encryptDataSection[ivSection];
                Guard.NotNullOrEmpty(encryptIv, ivConfigMessage);

                var getDataEncryptMessageOk = DataEncryptMessage.GetDataEncryptSuccess;
                var result = new DataEncrypt(encryptKey!, encryptIv!);

                return ApiResult.Ok(result, getDataEncryptMessageOk);
            }
            catch (Exception error)
            {
                var contextMessageInternalError = DataEncryptMessage.GetDataEncryptFailed;

                return ApiResult.InternalError<DataEncrypt>(contextMessageInternalError, error);
            }
        }

        public ApiResponse<string> EncryptDataMethod(string text)
        {
            try
            {
                var getEncryptData = GetDataEncrypt();

                var keySection = DataEncrypt.KeyConfigSection;
                var key = getEncryptData.Data.Key;
                Guard.NotNullOrEmpty(key, keySection);

                var ivSection = DataEncrypt.IvConfigSection;
                var iv = getEncryptData.Data.Iv;
                Guard.NotNullOrEmpty(iv, ivSection);

                var encryptDataMessage = DataEncryptMessage.EncryptDataSuccess;
                var encrypt = AES256Encryption.Encrypt(text, key!, iv!);

                return ApiResult.Ok(encrypt, encryptDataMessage);
            }
            catch (Exception error)
            {
                var contextMessageInternalError = DataEncryptMessage.EncryptDataFailed;

                return ApiResult.InternalError<string>(contextMessageInternalError, error);
            }
        }

        public ApiResponse<string> DecryptDataMethod(string text)
        {
            try
            {
                var getEncryptData = GetDataEncrypt();

                var keySection = DataEncrypt.KeyConfigSection;
                var key = getEncryptData.Data.Key;
                Guard.NotNullOrEmpty(key, keySection);

                var ivSection = DataEncrypt.IvConfigSection;
                var iv = getEncryptData.Data.Iv;
                Guard.NotNullOrEmpty(iv, ivSection);

                var decryptDataMessage = DataEncryptMessage.DecryptDataSuccess;
                var decrypt = AES256Encryption.Decrypt(text, key!, iv!);

                return ApiResult.Ok(decrypt, decryptDataMessage);
            }
            catch (Exception error)
            {
                var contextMessageInternalError = DataEncryptMessage.DecryptDataFailed;

                return ApiResult.InternalError<string>(contextMessageInternalError, error);
            }
        }

        public ApiResponse<string> EncryptPassword(string password) 
            => EncryptDataMethod(password);

        public ApiResponse<string> DecryptPassword(string password) 
            => DecryptDataMethod(password);

    }
}