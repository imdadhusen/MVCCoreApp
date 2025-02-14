using HisabPro.Constants;

namespace HisabPro.DTO.Response
{
    public class LoginRes
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public int UserRole { get; set; } = (int)EnumUserRole.User;
        public DateTime? PasswordChangedOn { get; set; }
        public bool MustChangePassword { get; set; }

        public int FailedLoginAttempts { get; set; }
        public DateTime? LockoutEnd { get; set; } 
        public bool IsLockedOut => LockoutEnd.HasValue && LockoutEnd.Value > DateTime.UtcNow;
    }
}
