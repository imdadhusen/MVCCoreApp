using HisabPro.Tools.CryptoService;
using Konscious.Security.Cryptography;
using System;
using System.Text;

namespace Hisab.Tools.PasswordService
{
    public static class Argon2PasswordHelper
    {
        // Function to create a hashed password
        public static string CreatePasswordHash(string password, out string salt)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Password cannot be null or whitespace.", nameof(password));

            // Generate a unique salt
            byte[] saltBytes = CryptoHelper.GenerateSalt(16);
            salt = Convert.ToBase64String(saltBytes);

            // Hash the password with Argon2
            var passwordHash = HashPassword(password, saltBytes);
            return passwordHash;
        }

        // Function to verify the hashed password
        public static bool VerifyPasswordHash(string password, string storedHash, string storedSalt)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Password cannot be null or whitespace.", nameof(password));

            byte[] saltBytes = Convert.FromBase64String(storedSalt);
            var computedHash = HashPassword(password, saltBytes);

            // Compare the stored hash with the computed hash
            return storedHash == computedHash;
        }

        // Helper function to hash a password using Argon2id
        private static string HashPassword(string password, byte[] salt)
        {
            using (var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password)))
            {
                argon2.Salt = salt;
                argon2.DegreeOfParallelism = 4; // Number of threads to use
                argon2.MemorySize = 65536;      // Memory size in KB (64 MB)
                argon2.Iterations = 4;          // Number of iterations

                // Generate the hash
                byte[] hashBytes = argon2.GetBytes(32); // 256-bit hash
                return Convert.ToBase64String(hashBytes);
            }
        }

        public static bool IsNewPasswordUnique(string newPassword, string storedHash, string storedSalt)
        {
            if (string.IsNullOrWhiteSpace(newPassword))
                throw new ArgumentException("Password cannot be null or whitespace.", nameof(newPassword));

            // Hash the new password using the same hashing process
            byte[] saltBytes = Convert.FromBase64String(storedSalt);
            string newHash = Argon2PasswordHelper.HashPassword(newPassword, saltBytes);

            // Compare the new hash with the stored hash
            return !newHash.Equals(storedHash);
        }
    }
}
