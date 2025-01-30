using HisabPro.Constants.Resources;

namespace HisabPro.Constants
{
    public static class FieldsSizeConst
    {
        public static class Account
        {
            public const int NameMin = 5;
            public const int NameMax = 15;
            public static string NameMessage = SharedResource.ValidationName; 

            public const int FullNameMax = 40;
            public static string FullNameMessage = SharedResource.ValidationFullName;
        }

        public static class User
        {
            public const int NameMin = 5;
            public const int NameMax = 20;
            public static string NameMessage = SharedResource.ValidationUser; 

            public const int PasswordSaltMin = 172;
            public const int PasswordSaltMax = 200; //This is for future use, as of now lengh exactly 172
            public static string PasswordSaltMessage = SharedResource.ValidationPasswordSalt; 

            public const int PasswordHashMin = 88;
            public const int PasswordHashMax = 100; //This is for future use, as of now lengh exactly 88
            public static string PasswordHashMessage = SharedResource.ValidationPasswordHash; 

            public const int TokenMin = 88;

            public const int NewPasswordMin = 8;
            public static string NewPasswordMessage = SharedResource.ValidationPasswordNew;
            public static string ConfirmPasswordMessage = SharedResource.ValidationPasswordConfirm; 
        }
    }
}
