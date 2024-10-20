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
    }
}
