namespace VMT.ERP.Utils.Security.Models.Encrypt
{
    public class DataEncrypt(string key)
    {
        public const string EncrypDataSection = "EncrypData";
        public const string EncryptKey = "Key";
        public string? Key { get; set; } = key;
    }
}