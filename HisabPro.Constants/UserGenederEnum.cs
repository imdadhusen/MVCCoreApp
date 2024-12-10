namespace HisabPro.Constants
{
    public enum UserGenederEnum
    {
        [EnumText(AuthorizePolicy.NameGenederMale)]
        Male = 1,
        [EnumText(AuthorizePolicy.NameGenederFemale)]
        Female = 2,
        [EnumText(AuthorizePolicy.NameGenederOther)]
        Other = 3,
    }
}
