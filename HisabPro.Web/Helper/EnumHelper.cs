using HisabPro.Constants;
using HisabPro.DTO.Response;
using System.Reflection;

namespace HisabPro.Web.Helper
{
    public static class EnumHelper
    {
        public static List<IdNameRes> ToIdNameList<TEnum>() where TEnum : Enum
        {
            return Enum.GetValues(typeof(TEnum))
                .Cast<TEnum>()
                .Select(e => new IdNameRes
                {
                    Id = Convert.ToInt32(e).ToString(),
                    Name = e.GetEnumText() ?? e.ToString()
                })
                .ToList();
        }

        public static string GetEnumText(this Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attribute = field?.GetCustomAttribute<EnumTextAttribute>();
            return attribute?.GetLocalizedValue(); //attribute?.Text;
        }
    }
}
