using Hisab.Tools.PasswordService;
using System;

namespace HisabPro.Tools.Execute
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string s = CryptoHelper.GenerateSalt(16).ToString();
            string salt;
            string password = "imdad@123";
            string hash = Argon2PasswordHelper.CreatePasswordHash(password, out salt);
            Console.WriteLine($"Password:{password}, Hash:{hash}, Salt:{salt}");
        }
    }
}
