using System.Security.Cryptography;
using System.Text;

namespace API.Utility;

public class AesEncrypt
{
    public static string KEY = "eduSyncErp@2024_";
    public static string IV  = "qo8D6j8Z5c9V4s7B";

    public static string EncryptString(string text)
    {
        byte[] key = Encoding.UTF8.GetBytes(KEY);
        byte[] iv = Encoding.UTF8.GetBytes(IV);
        byte[] encrypted;

        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = key;
            aesAlg.IV = iv;

            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

            using (MemoryStream msEncrypt = new MemoryStream())
            {
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(text);
                    }
                    encrypted = msEncrypt.ToArray();
                }
            }
        }

        return Convert.ToBase64String(encrypted);
    }
}