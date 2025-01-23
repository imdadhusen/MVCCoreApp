using System.Globalization;
using System.Reflection;
using System.Resources;

namespace HisabPro.Constants.Resources
{
    public class SharedResource
    {
        private static readonly ResourceManager _resourceManager = new ResourceManager("HisabPro.Constants.Resources.SharedResource", Assembly.GetExecutingAssembly());
        private static readonly CultureInfo _culture = CultureInfo.CurrentUICulture;

        public static string MessageWelcome { get; private set; }

        public static string FieldEmail { get; private set; }
        public static string FieldPassword { get; private set; }
        public static string FieldRememberMe { get; private set; }

        public static string ValidationInvalidEmail { get; private set; }
        public static string ValidationRequiredEmail { get; private set; }
        public static string ValidationRequiredPassword { get; private set; }

        public static string LabelHello { get; private set; }
        public static string LabelAboutUs { get; private set; }
        public static string LabelContact { get; private set; }
        public static string LabelHome { get; private set; }
        public static string LabelLogin { get; private set; }
        public static string LabelPrivacy { get; private set; }
        public static string LabelRegisterUser { get; private set; }
        public static string LabelDashboard { get; private set; }
        public static string LabelProfile { get; private set; }
        public static string LabelChangePassword { get; private set; }
        public static string LabelLogout { get; private set; }

        static SharedResource()
        {
            var properties = typeof(SharedResource).GetProperties(BindingFlags.Public | BindingFlags.Static | BindingFlags.GetProperty | BindingFlags.SetProperty);

            foreach (var property in properties)
            {
                if (property.PropertyType == typeof(string))
                {
                    var key = property.Name;
                    var value = _resourceManager.GetString(key, _culture) ?? string.Empty;
                    property.SetValue(null, value);
                }
            }
        }
    }
}