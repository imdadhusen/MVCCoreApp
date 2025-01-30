using HisabPro.Constants.Resources;

namespace HisabPro.Constants
{
    public class FieldsSizeCommonConst
    {
        public static class Mobile
        {
            public const int Len = 10;
            public const string RegEx = @"^\d{10}$";
            public static string Message = SharedResource.ValidationMobile;
            public static string RegExMessage = Message;
        }

        public static class Email
        {
            public const int Min = 10;
            public const int Max = 50;
            public static string Message = SharedResource.ValidationEmail;

            public const string RegEx = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            public static string RegExMessage = SharedResource.ValidationInvalidEmail;
        }

        public static string DateOnlyMessage = SharedResource.ValidationDate;
        public static string NumberMessage = SharedResource.ValidationAmount;

        public const int TitleMin = 3;
        public const int TitleMax = 25;
        public static string TitleMessage = SharedResource.ValidationTitle;

        public const int NoteMax = 250;
        public static string NoteMessage = SharedResource.ValidationNote;

        public const int CategoryMin = 3;
        public const int CategoryMax = 50;
        public static string CategoryMessage = SharedResource.ValidationCategory;
    }
}
