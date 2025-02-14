using System.Reflection;

namespace HisabPro.Constants
{
    public static class EnumLocalizationHelper
    {
        private static ISharedViewLocalizer _localizer;

        public static void Configure(ISharedViewLocalizer localizer)
        {
            _localizer = localizer;
        }

        public static string Get<TEnum>(TEnum value) where TEnum : Enum
        {
            var fieldInfo = typeof(TEnum).GetField(value.ToString());
            var attribute = fieldInfo?.GetCustomAttribute<EnumTextAttribute>();

            if (attribute != null && _localizer != null)
            {
                return _localizer.Get(attribute.ResourceKey);
            }

            return value.ToString(); // Fallback to enum name
        }
    }
}
