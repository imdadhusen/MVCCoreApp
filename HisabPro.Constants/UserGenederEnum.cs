using HisabPro.Constants.Resources;

namespace HisabPro.Constants
{
    public enum UserGenederEnum
    {
        [EnumText(ResourceKey.LabelGenderMale)]
        Male = 1,
        [EnumText(ResourceKey.LabelGenderFemale)]
        Female = 2,
        [EnumText(ResourceKey.LabelGenderOther)]
        Other = 3,
    }
}
