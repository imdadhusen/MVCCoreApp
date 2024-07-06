using HisabPro.Tools.CryptoService;
using HisabPro.Tools.PasswordService;
using System;

namespace HisabPro.Tools.Execute
{
    internal class Program
    {
        static void Main(string[] args)
        {
           string s =  CryptoHelper.GenerateSalt(16).ToString();

            string hash;
            string salt;
            string password = "imdad@123";
            PasswordHelper.CreatePasswordHash(password, out hash, out salt);
            Console.WriteLine($"Password:{password}, Hash:{hash}, Salt:{salt}");
        }
    }
}
