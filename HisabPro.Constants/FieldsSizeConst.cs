namespace HisabPro.Constants
{
    public static class FieldsSizeConst
    {
        public static class Account
        {
            public const int NameMin = 5;
            public const int NameMax = 15;
            public const string NameMessage = "Accout name must be between 5 and 15 characters.";

            public const int FullNameMax = 40;
            public const string FullNameMessage = "Full name cannot exceed 40 characters.";
        }

        public static class User
        {
            public const int NameMin = 5;
            public const int NameMax = 20;
            public const string NameMessage = "User name must be between 5 and 20 characters.";

            public const int PasswordSaltMin = 172;
            public const int PasswordSaltMax = 200; //This is for future use, as of now lengh exactly 172
            public const string PasswordSaltMessage = "Password salt must be between 172 and 200 characters.";

            public const int PasswordHashMin = 88;
            public const int PasswordHashMax = 100; //This is for future use, as of now lengh exactly 88
            public const string PasswordHashMessage = "Password hash must be between 88 and 100 characters.";
        }
    }
}
