namespace HisabPro.Constants
{
    public class FieldsSizeCommonConst
    {
        public static class Mobile
        {
            public const int Len = 10;
            public const string RegEx = @"^\d{10}$";
        }

        public static class Email
        {
            public const int Min = 10;
            public const int Max = 50;

            public const string RegEx = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
        }

        public const int TitleMin = 3;
        public const int TitleMax = 25;

        public const int NoteMax = 250;

        public const int CategoryMin = 3;
        public const int CategoryMax = 50;
    }
}
