namespace HisabPro.Constants
{
    public enum UserRoleEnum
    {
        [EnumText(AuthorizePolicy.NameRoleSuperAdmin)]
        SuperAdmin = 1,
        [EnumText(AuthorizePolicy.NameRoleAdmin)]
        Admin = 2,
        [EnumText(AuthorizePolicy.NameRoleUser)]
        User = 3
    }
}
