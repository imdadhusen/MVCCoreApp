namespace HisabPro.Constants
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class EnumTextAttribute : Attribute
    {
        public string ResourceKey { get; }

        public EnumTextAttribute(string resourceKey)
        {
            ResourceKey = resourceKey;
        }
    }
}
