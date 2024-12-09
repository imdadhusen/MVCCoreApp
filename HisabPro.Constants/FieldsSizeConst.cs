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

            public const int EmailMax = 50;
            public const string EmailMessage = "Email address cannot exceed 50 characters.";

            public const string EmailRegEx = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            public const string EmailRegExMessage = "Invalid email address.";
        }
    }
}
