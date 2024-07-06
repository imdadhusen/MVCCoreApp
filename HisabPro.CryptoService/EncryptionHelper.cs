using System.IO;
using System.Security.Cryptography;
using System.Text;
using System;

namespace Hisab.CryptoService
{
    public static class EncryptionHelper
    {
        //TODO: This needs to be set and read from config
        private static readonly string EncryptionKey = "EncryptionKey456"; // 16 characters long

        public static string Encrypt(string text)
        {
            if (string.IsNullOrEmpty(text))
                return text;

            var key = Encoding.UTF8.GetBytes(EncryptionKey.Substring(0, 16));
            using (var aesAlg = Aes.Create())
            {
                using (var encryptor = aesAlg.CreateEncryptor(key, aesAlg.IV))
                {
                    using (var msEncrypt = new MemoryStream())
                    {
                        using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                        {
                            using (var swEncrypt = new StreamWriter(csEncrypt))
                            {
                                swEncrypt.Write(text);
                            }
                        }
                        var iv = aesAlg.IV;
                        var encryptedContent = msEncrypt.ToArray();
                        var result = new byte[iv.Length + encryptedContent.Length];
                        Buffer.BlockCopy(iv, 0, result, 0, iv.Length);
                        Buffer.BlockCopy(encryptedContent, 0, result, iv.Length, encryptedContent.Length);
                        return Convert.ToBase64String(result);
                    }
                }
            }
        }

        public static string Decrypt(string cipherText)
        {
            if (string.IsNullOrEmpty(cipherText))
                return cipherText;

            var fullCipher = Convert.FromBase64String(cipherText);
            var iv = new byte[16];
            var cipher = new byte[fullCipher.Length - iv.Length];

            Buffer.BlockCopy(fullCipher, 0, iv, 0, iv.Length);
            Buffer.BlockCopy(fullCipher, iv.Length, cipher, 0, cipher.Length);
            var key = Encoding.UTF8.GetBytes(EncryptionKey.Substring(0, 16));

            using (var aesAlg = Aes.Create())
            {
                using (var decryptor = aesAlg.CreateDecryptor(key, iv))
                {
                    using (var msDecrypt = new MemoryStream(cipher))
                    {
                        using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {
                            using (var srDecrypt = new StreamReader(csDecrypt))
                            {
                                return srDecrypt.ReadToEnd();
                            }
                        }
                    }
                }
            }
        }
    }
}