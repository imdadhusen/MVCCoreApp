using HisabPro.Constants.Resources;
using System.ComponentModel.Design;

namespace HisabPro.Constants
{
    public enum EnumUserRole
    {
        [EnumText(ResourceKey.LabelRoleSuperAdmin)]
        SuperAdmin = 1,
        [EnumText(ResourceKey.LabelRoleAdmin)]
        Admin = 2,
        [EnumText(ResourceKey.LabelRoleUser)]
        User = 3
    }
}
