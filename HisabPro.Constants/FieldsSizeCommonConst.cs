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

        public const string DateOnlyMessage = "Please enter a valid date.";
        public const string NumberMessage = "Amount must be an integer value.";

        public const int TitleMin = 3;
        public const int TitleMax = 25;
        public const string TitleMessage = "Title must be between 3 and 25 characters.";

        public const int NoteMax = 100;
        public const string NoteMessage = "Note cannot exceed 100 characters.";
    }
}
