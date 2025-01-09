using HisabPro.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HisabPro.Entities.Models
{
    public class User : AuditableEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(FieldsSizeConst.User.NameMax, MinimumLength = FieldsSizeConst.User.NameMin, ErrorMessage = FieldsSizeConst.User.NameMessage)]
        public string Name { get; set; }
        [Required]
        [StringLength(FieldsSizeCommonConst.Email.Max, MinimumLength = FieldsSizeCommonConst.Email.Min, ErrorMessage = FieldsSizeCommonConst.Email.Message)]
        [RegularExpression(FieldsSizeCommonConst.Email.RegEx, ErrorMessage = FieldsSizeCommonConst.Email.RegExMessage)]
        public string Email { get; set; }
        [Required]
        [StringLength(FieldsSizeCommonConst.Mobile.Len, MinimumLength = FieldsSizeCommonConst.Mobile.Len, ErrorMessage = FieldsSizeCommonConst.Mobile.Message)]
        [RegularExpression(FieldsSizeCommonConst.Mobile.RegEx, ErrorMessage = FieldsSizeCommonConst.Mobile.RegExMessage)]
        public string Mobile { get; set; }
        [Required]
        public int UserRole { get; set; } = (int)UserRoleEnum.User;
        [Required]
        public int Gender { get; set; } = (int)UserGenederEnum.Male;

        [StringLength(FieldsSizeConst.User.PasswordHashMax, MinimumLength = FieldsSizeConst.User.PasswordHashMin, ErrorMessage = FieldsSizeConst.User.PasswordHashMessage)]
        public string? PasswordHash { get; set; }
        [StringLength(FieldsSizeConst.User.PasswordSaltMax, MinimumLength = FieldsSizeConst.User.PasswordSaltMin, ErrorMessage = FieldsSizeConst.User.PasswordHashMessage)]
        public string? PasswordSalt { get; set; }
        [StringLength(FieldsSizeConst.User.TokenMin)]
        public string? Token { get; set; }
        public DateTime? TokenExpiry { get; set; }
        public DateTime? PasswordChangedOn { get; set; }
        public bool MustChangePassword { get; set; } = false; //Admin reset or Password recovery/reset

        // lockout properties
        public int FailedLoginAttempts { get; set; } = 0; // Track the number of failed login attempts
        public DateTime? LockoutEnd { get; set; } // Track when the lockout ends
        public bool IsLockedOut => LockoutEnd.HasValue && LockoutEnd.Value > DateTime.UtcNow; // Determines if the user is locked out
    }
}
