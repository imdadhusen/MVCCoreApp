namespace HisabPro.Constants
{
    public class AppSettings
    {
        public UserSettings User { get; set; }

        public class UserSettings
        {
            public int PasswordResetExpiryHours { get; set; }
        }
    }
}
