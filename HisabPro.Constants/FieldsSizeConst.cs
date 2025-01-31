namespace HisabPro.Constants
{
    public static class FieldsSizeConst
    {
        public static class Account
        {
            public const int NameMin = 5;
            public const int NameMax = 15;

            public const int FullNameMax = 40;
        }

        public static class User
        {
            public const int NameMin = 5;
            public const int NameMax = 20;

            public const int PasswordSaltMin = 172;
            public const int PasswordSaltMax = 200; //This is for future use, as of now lengh exactly 172

            public const int PasswordHashMin = 88;
            public const int PasswordHashMax = 100; //This is for future use, as of now lengh exactly 88

            public const int TokenMin = 88;

            public const int NewPasswordMin = 8;
        }
    }
}
