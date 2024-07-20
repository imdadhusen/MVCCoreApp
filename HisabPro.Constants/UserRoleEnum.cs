namespace HisabPro.Constants
{
    public enum UserRoleEnum
    {
        [EnumText(AuthorizePolicy.NameRoleAdmin)]
        Admin = 1,
        [EnumText(AuthorizePolicy.NameRoleUser)]
        User = 2
    }
}
