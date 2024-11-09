namespace HisabPro.Constants
{
    public static partial class AppConst
    {
        public static class ApiMessage
        {
            public const string ValidationFailed = "Validation failed";
            public const string Save = "Data saved successfully";
            public const string InternalError = "Internal server error";
            public const string Delete = "Data deleted successfully";
            public const string ReferenceDeleteError = "Reference data cannot be deleted as it is linked to other records";
            public const string NotFound = "Data not found";
            public const string DataWithSameName = "Data with same name already exists";
            public const string DataRetrived = "Data retrived successfully";
            public const string DataRetrivedFailed = "Data retrived failed";
        }
    }
}
