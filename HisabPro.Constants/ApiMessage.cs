namespace HisabPro.Constants
{
    public static partial class AppConst
    {
        public static class ApiMessage
        {
            public const string ValidationFailed = "Validation failed";
            public const string Save = "Data saved successfully";
            public const string UserNotFound = "User not found";
            public const string PasswordShouldNotMatchCurrent = "New password cannot be the same as the current password";
            public const string PasswordUpdated = "Password changed successfully";
            public const string UserActivate = "User activated successfully";
            public const string UserActivateFailed = "User activation failed";
            public const string UserDeactivate = "User deactivated successfully";
            public const string UserDeactivateFailed = "User deactivation failed";
            public const string InternalError = "Internal server error";
            public const string Delete = "Data deleted successfully";
            public const string ReferenceDeleteError = "Reference data cannot be deleted as it is linked to other records";
            public const string NotFound = "Data not found";
            public const string DataWithSameName = "Data with same name already exists";
            public const string SameNameInStandardCategory = "A duplicate name already exists within the standard category.";
            public const string DataRetrived = "Data retrived successfully";
            public const string DataRetrivedFailed = "Data retrived failed";
            public const string DataImportSuccess = "Data imported successfully";

            public const string ImportFileAllowedExtensions = "Only .xls and .xlsx files are allowed";
            public const string ImportSuccess = "File uploaded successfully";
            public const string ImportFileRequired = "Please select a file to upload";
        }
    }
}
