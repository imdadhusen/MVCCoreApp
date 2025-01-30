using HisabPro.Constants.Resources;

namespace HisabPro.Constants
{
    public enum UserGenederEnum
    {
        [EnumText(typeof(SharedResource), nameof(SharedResource.LabelGenderMale))]
        Male = 1,
        [EnumText(typeof(SharedResource), nameof(SharedResource.LabelGenderFemale))]
        Female = 2,
        [EnumText(typeof(SharedResource), nameof(SharedResource.LabelGenderOther))]
        Other = 3,
    }
}
