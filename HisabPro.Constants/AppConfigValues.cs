namespace HisabPro.Constants
{
    public class AppSettings
    {
        public UserSettings User { get; set; }
        public string ApiUrl { get; set; }
        public string SupportEmail { get; set; }
        public string PrivacyLinkAction { get; set; }
        public string TermsAndConditionLinkAction { get; set; }

        public class UserSettings
        {
            public int PasswordResetExpiryHours { get; set; }
            public int MustChangePasswordInDays { get; set; }
            public int MaxLoginAttempts { get; set; }
            public int AccountLockedForMins { get; set; }

        }
    }
}
