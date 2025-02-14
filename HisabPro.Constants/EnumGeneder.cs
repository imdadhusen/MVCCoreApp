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
}
