using HisabPro.Constants.Resources;

namespace HisabPro.Constants
{
    public enum EnumGeneder
    {
        [EnumText(ResourceKey.LabelGenderMale)]
        Male = 1,
        [EnumText(ResourceKey.LabelGenderFemale)]
        Female = 2,
        [EnumText(ResourceKey.LabelGenderOther)]
        Other = 3,
    }

    public class EnumGenederLocalization
    {
        public static string Male { get; set; }
        public static string Female { get; set; }
        public static string Other { get; set; }

        public static string Get(int roleValue)
        {
            if (roleValue == 1)
                return Male;
            if (roleValue == 2)
                return Female;
            return Other;
        }
    }
}
