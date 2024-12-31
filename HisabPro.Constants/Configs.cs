namespace HisabPro.Constants
{
    public static partial class AppConst
    {
        public static class Configs
        {
            public const string DatabaseConnectionString = "DefaultConnection";
            public const string JwtKey = "Jwt:Key";
            public const string JwtIssuer = "Jwt:Issuer";
            public const string JwtAudience = "Jwt:Audience";

            public const string UploadFolderPath = "wwwroot/uploads";
            public const string EmailTemplatesFolder = "EmailTemplates";
        }
    }
}
