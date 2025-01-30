using System.Reflection;

namespace HisabPro.Constants
{
    //[AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    //public class EnumTextAttribute : Attribute
    //{
    //    public string Text { get; }

    //    public EnumTextAttribute(string text)
    //    {
    //        Text = text;
    //    }
    //}
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class EnumTextAttribute : Attribute
    {
        public Type ResourceType { get; }
        public string ResourceName { get; }

        public EnumTextAttribute(Type resourceType, string resourceName)
        {
            ResourceType = resourceType;
            ResourceName = resourceName;
        }

        public string GetLocalizedValue()
        {
            if (ResourceType != null && !string.IsNullOrEmpty(ResourceName))
            {
                PropertyInfo property = ResourceType.GetProperty(ResourceName, BindingFlags.Static | BindingFlags.Public);
                return property?.GetValue(null)?.ToString() ?? ResourceName;
            }
            return ResourceName;
        }
    }
}
