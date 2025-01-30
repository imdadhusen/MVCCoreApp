using HisabPro.Constants;
using System.Reflection;

public static class EnumExtensions
{
    //public static string GetText(this Enum value)
    //{
    //    FieldInfo field = value.GetType().GetField(value.ToString());

    //    if (field != null)
    //    {
    //        var attribute = (EnumTextAttribute)Attribute.GetCustomAttribute(field, typeof(EnumTextAttribute));
    //        if (attribute != null)
    //        {
    //            return attribute.Text;
    //        }
    //    }

    //    return value.ToString(); // Fallback to enum name if no description is found
    //}
    public static string GetEnumLocalizedText(this Enum value)
    {
        FieldInfo field = value.GetType().GetField(value.ToString());
        EnumTextAttribute attribute = field?.GetCustomAttribute<EnumTextAttribute>();

        return attribute?.GetLocalizedValue() ?? value.ToString();
    }
}
