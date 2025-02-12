using HisabPro.Constants.Resources;

namespace HisabPro.Constants
{
    public enum UserRoleEnum
    {
        [EnumText(ResourceKey.LabelRoleSuperAdmin)]
        SuperAdmin = 1,
        [EnumText(ResourceKey.LabelRoleAdmin)]
        Admin = 2,
        [EnumText(ResourceKey.LabelRoleUser)]
        User = 3
    }
}
