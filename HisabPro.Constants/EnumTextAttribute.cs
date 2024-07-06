namespace HisabPro.Constants
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class EnumTextAttribute : Attribute
    {
        public string Text { get; }

        public EnumTextAttribute(string text)
        {
            Text = text;
        }
    }
}
