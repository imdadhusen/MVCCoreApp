using HisabPro.Constants.Resources;

namespace HisabPro.Constants
{
    public static partial class AppConst
    {
        public static class ApiMessage
        {
            public static class LoginMsg
            {
                public static string EMailNotFound = SharedResource.LabelEmailNotFound;
                public static string AccountLocked = SharedResource.LabelApiAccountLocked;
                public static string InvalidAttempt = SharedResource.LabelApiInvalidAttempt;
                public static string AccountLockedWithUnlockTime = SharedResource.LabelApiAccountLockedWithUnlockTime;
                public static string Success = SharedResource.LabelApiLoginSuccess;
            }

            public static string ValidationFailed = SharedResource.LabelApiValidationFailed;
            public static string Save = SharedResource.LabelApiSave;
            public static string UserNotFound = SharedResource.LabelApiUserNotFound;
            public static string PasswordShouldNotMatchCurrent = SharedResource.LabelApiPasswordShouldNotMatchCurrent;
            public static string PasswordUpdated = SharedResource.LabelApiPasswordUpdated;
            public static string UserActivate = SharedResource.LabelApiUserActivate;
            public static string UserActivateFailed = SharedResource.LabelApiUserActivateFailed;
            public static string UserDeactivate = SharedResource.LabelApiUserDeactivate;
            public static string UserDeactivateFailed = SharedResource.LabelApiUserDeactivateFailed;
            public static string InternalError = SharedResource.LabelApiInternalError;
            public static string Delete = SharedResource.LabelApiDelete;
            public static string ReferenceDeleteError = SharedResource.LabelApiReferenceDeleteError;
            public static string NotFound = SharedResource.LabelApiNotFound;
            public static string DataWithSameName = SharedResource.LabelApiDataWithSameName;
            public static string SameNameInStandardCategory = SharedResource.LabelApiSameNameInStandardCategory;
            public static string DataRetrived = SharedResource.LabelApiDataRetrived;
            public static string DataRetrivedFailed = SharedResource.LabelApiDataRetrivedFailed;
            public static string DataImportSuccess = SharedResource.LabelApiDataImportSuccess;

            public static string ImportFileAllowedExtensions = SharedResource.LabelApiImportFileAllowedExtensions;
            public static string ImportSuccess = SharedResource.LabelApiImportSuccess;
            public static string ImportFileRequired = SharedResource.LabelApiImportFileRequired;
        }
    }
}
