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
            public const string AccessDenied = "/Home/AccessDenied";
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

        public static class ApiMessage
        {
            public const string ValidationFailed = "Validation failed";
            public const string Save = "Data saved successfully";
            public const string InternalError = "Internal server error";
            public const string Delete = "Data deleted successfully";
            public const string ReferenceDeleteError = "Reference data cannot be deleted as it is linked to other records";
            public const string NotFound = "Data not found";
            public const string DataWithSameName = "Data with this name already exists";
            public const string DataRetrived = "Data retrived successfully";
            public const string DataRetrivedFailed = "Data retrived failed";
        }
    }
}
