using System.Security.Cryptography;

namespace HisabPro.Tools.CryptoService
{
    public class CryptoHelper
    {
        public static byte[] GenerateSalt(int size = 32)
        {
            var salt = new byte[size];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }
    }
}
