using System.Security.Cryptography;
using System.Text;

namespace VMT.ERP.Utils.Encryption
{
    public static class AES256Encryption
    {
        public static string Encrypt(string plainText, string key, string iv)
        {
            using var aesAlgorith = Aes.Create();

            var encodingKey = Encoding.UTF8.GetBytes(key);
            var encodingIv = Encoding.UTF8.GetBytes(iv);

            aesAlgorith.Key = encodingKey;
            aesAlgorith.IV = encodingIv;

            using var encryptor = aesAlgorith.CreateEncryptor(aesAlgorith.Key, aesAlgorith.IV);
            using var memmoryStream = new MemoryStream();
            using var cryptoStream = new CryptoStream(memmoryStream, encryptor, CryptoStreamMode.Write);
            using var streamWriter = new StreamWriter(cryptoStream);

            streamWriter.Write(plainText);
            streamWriter.Flush();
            cryptoStream.FlushFinalBlock();

            return Convert.ToBase64String(memmoryStream.ToArray());
        }

        public static string Decrypt(string cipherText, string key, string iv)
        {
            using var aesAlgorith = Aes.Create();

            var encodingKey = Encoding.UTF8.GetBytes(key);
            var encodingIv = Encoding.UTF8.GetBytes(iv);

            aesAlgorith.Key = encodingKey;
            aesAlgorith.IV = encodingIv;

            var convert = Convert.FromBase64String(cipherText);
            using var memmoryStream = new MemoryStream(convert);
            using var decryptor = aesAlgorith.CreateDecryptor(aesAlgorith.Key, aesAlgorith.IV);
            using var cryptoStream = new CryptoStream(memmoryStream, decryptor, CryptoStreamMode.Read);
            using var streamReader = new StreamReader(cryptoStream);

            return streamReader.ReadToEnd();
        }
    }
}