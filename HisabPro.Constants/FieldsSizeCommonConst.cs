namespace HisabPro.Constants
{
    public class FieldsSizeCommonConst
    {
        public static class Mobile
        {
            public const int Len = 10;
            public const string RegEx = @"^\d{10}$";
            public const string Message = "Mobile number must be exactly 10 digits.";
            public const string RegExMessage = Message;
        }

        public static class Email
        {
            public const int Min = 10;
            public const int Max = 50;
            public const string Message = "Email address must be between 10 and 50 characters.";

            public const string RegEx = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            public const string RegExMessage = "Invalid email address.";
        }

        public const string DateOnlyMessage = "Please enter a valid date.";
        public const string NumberMessage = "Amount must be an integer value.";

        public const int TitleMin = 3;
        public const int TitleMax = 25;
        public const string TitleMessage = "Title must be between 3 and 25 characters.";

        public const int NoteMax = 250;
        public const string NoteMessage = "Note cannot exceed 250 characters.";

        public const int CategoryMin = 3;
        public const int CategoryMax = 50;
        public const string CategoryMessage = "Category must be between 3 and 50 characters.";
    }
}
