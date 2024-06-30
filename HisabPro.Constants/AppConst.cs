namespace HisabPro.Constants
{
    public static class AppConst
    {
        public static class Views
        {
            public const string Unauthorized = "/Home/Unauthorized";
            public const string Login = "/Account/Login";
            public const string Logout = "/Account/Logout";
            public const string Error = "/Home/Error";
        }

        public static class Cookies
        {
            public const string RememberMe = "RememberUserId";
        }

        public static class Configs
        {
            public const string DatabaseConnectionString = "connectionStrings:DefaultConnection";
            public const string JwtKey = "Jwt:Key";
            public const string JwtIssuer = "Jwt:Issuer";
            public const string JwtAudience = "Jwt:Audience";
        }
    }
}
