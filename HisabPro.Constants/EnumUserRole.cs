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

    public class EnumUserRoleLocalization
    {
        public static string SuperAdmin { get; set; }
        public static string Admin { get; set; }
        public static string User { get; set; }

        public static string Get(int roleValue)
        {
            if (roleValue == 1)
                return SuperAdmin;
            if (roleValue == 2)
                return Admin;
            return User;
        }
    }
}
