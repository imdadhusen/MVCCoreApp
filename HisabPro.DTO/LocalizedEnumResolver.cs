using AutoMapper;
using HisabPro.Constants;
using System.Reflection;

namespace HisabPro.DTO
{
    public class LocalizedEnumResolver<TSource, TEnum> : IValueResolver<TSource, object, string>
        where TEnum : struct, Enum
    {
        private readonly ISharedViewLocalizer _localizer;
        private readonly string _enumPropertyName;

        public LocalizedEnumResolver(ISharedViewLocalizer localizer, string enumPropertyName)
        {
            _localizer = localizer;
            _enumPropertyName = enumPropertyName;
        }

        public string Resolve(TSource source, object destination, string destMember, ResolutionContext context)
        {
            if (source == null) return string.Empty;

            // Get the enum property dynamically
            PropertyInfo property = typeof(TSource).GetProperty(_enumPropertyName);
            if (property == null) return string.Empty;

            object enumValue = property.GetValue(source);
            if (enumValue is TEnum enumTypedValue)
            {
                return _localizer.Get(enumTypedValue.ToString());
            }

            return string.Empty;
        }
    }

}
