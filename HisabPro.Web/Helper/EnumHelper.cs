using HisabPro.Constants;
using HisabPro.DTO.Response;
using Microsoft.Extensions.Localization;
using System.ComponentModel;
using System.Reflection;

namespace HisabPro.Web.Helper
{
    public static class EnumHelper
    {
        public static List<IdNameRes> ToIdNameList<TEnum>(ISharedViewLocalizer _localizer) where TEnum : Enum
        {
            return Enum.GetValues(typeof(TEnum))
                .Cast<TEnum>()
                .Select(e => new IdNameRes
                {
                    Id = Convert.ToInt32(e).ToString(),
                    Name = e.GetLocalizedEnumText(_localizer) ?? e.ToString()
                })
                .ToList();
        }

        //public static string GetEnumText(this Enum value)
        //{
        //    //var field = value.GetType().GetField(value.ToString());
        //    //var attribute = field?.GetCustomAttribute<EnumTextAttribute>();
        //    //return attribute?.get .GetLocalizedValue(); //attribute?.Text;
        //}

        public static string GetLocalizedEnumText<T>(this T value, ISharedViewLocalizer _localizer) where T : Enum
        {
            FieldInfo field = value.GetType().GetField(value.ToString());

            if (field != null)
            {
                EnumTextAttribute attribute = field.GetCustomAttribute<EnumTextAttribute>();
                if (attribute != null)
                {
                    return _localizer.Get(attribute.ResourceKey);
                }

                // Fallback to default description
                DescriptionAttribute descAttribute = field.GetCustomAttribute<DescriptionAttribute>();
                if (descAttribute != null)
                {
                    return descAttribute.Description;
                }
            }

            return value.ToString(); // Fallback to enum name
        }
    }
}
