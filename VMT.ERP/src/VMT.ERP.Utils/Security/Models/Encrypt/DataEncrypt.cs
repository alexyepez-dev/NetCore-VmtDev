namespace VMT.ERP.Utils.Security.Models.Encrypt
{
    public class DataEncrypt(string key, string iv)
    {
        public const string EncrypDataSection = "EncrypData";
        public const string EncryptKey = "Key";

        public const string KeyConfigMessage = "Key es requerido";
        public const string IvConfigMessage = "Iv es requerido";

        public const string KeyConfigSection = "Key";
        public const string IvConfigSection = "Iv";

        public string? Key { get; set; } = key;
        public string? Iv { get; set; } = iv;
    }
}