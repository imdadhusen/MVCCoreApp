using HisabPro.Constants.Resources;

namespace HisabPro.Constants
{
    public enum UserRoleEnum
    {
        [EnumText(typeof(SharedResource), nameof(SharedResource.LabelRoleSuperAdmin))]
        SuperAdmin = 1,
        [EnumText(typeof(SharedResource), nameof(SharedResource.LabelRoleAdmin))]
        Admin = 2,
        [EnumText(typeof(SharedResource), nameof(SharedResource.LabelRoleUser))]
        User = 3
    }
}
