using HisabPro.Constants.Resources;
using Microsoft.Extensions.Localization;
using System.Reflection;

namespace HisabPro.Constants
{
    public interface ISharedViewLocalizer
    {
        public LocalizedString this[string key]
        {
            get;
        }

        LocalizedString Get(string key);
    }

    public class SharedViewLocalizer : ISharedViewLocalizer
    {
        private readonly IStringLocalizer _localizer;

        public SharedViewLocalizer(IStringLocalizerFactory factory)
        {
            var type = typeof(SharedResource);
            var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
            _localizer = factory.Create("SharedResource", assemblyName.Name);
        }

        public LocalizedString this[string key] => _localizer[key];

        public LocalizedString Get(string key)
        {
            return _localizer[key];
        }
    }
}
