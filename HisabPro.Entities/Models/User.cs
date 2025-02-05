using HisabPro.Constants;
using HisabPro.Constants.Resources;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HisabPro.Entities.Models
{
    public class User : AuditableEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessageResourceType = typeof(SharedResource), ErrorMessageResourceName = nameof(SharedResource.ValidationRequired))]
        [StringLength(FieldsSizeConst.User.NameMax, MinimumLength = FieldsSizeConst.User.NameMin, ErrorMessageResourceType = typeof(SharedResource), ErrorMessageResourceName = nameof(SharedResource.ValidationName))]
        public string Name { get; set; }
        [Required(ErrorMessageResourceType = typeof(SharedResource), ErrorMessageResourceName = nameof(SharedResource.ValidationRequired))]
        [StringLength(FieldsSizeCommonConst.Email.Max, MinimumLength = FieldsSizeCommonConst.Email.Min, ErrorMessageResourceType = typeof(SharedResource), ErrorMessageResourceName = nameof(SharedResource.ValidationEmail))]
        [RegularExpression(FieldsSizeCommonConst.Email.RegEx, ErrorMessageResourceType = typeof(SharedResource), ErrorMessageResourceName = nameof(SharedResource.ValidationInvalidEmail))]
        public string Email { get; set; }
        [Required(ErrorMessageResourceType = typeof(SharedResource), ErrorMessageResourceName = nameof(SharedResource.ValidationRequired))]
        [StringLength(FieldsSizeCommonConst.Mobile.Len, MinimumLength = FieldsSizeCommonConst.Mobile.Len, ErrorMessageResourceType = typeof(SharedResource), ErrorMessageResourceName = nameof(SharedResource.ValidationMobile))]
        [RegularExpression(FieldsSizeCommonConst.Mobile.RegEx, ErrorMessageResourceType = typeof(SharedResource), ErrorMessageResourceName = nameof(SharedResource.ValidationMobile))]
        public string Mobile { get; set; }
        [Required(ErrorMessageResourceType = typeof(SharedResource), ErrorMessageResourceName = nameof(SharedResource.ValidationRequired))]
        public int UserRole { get; set; } = (int)UserRoleEnum.User;
        [Required(ErrorMessageResourceType = typeof(SharedResource), ErrorMessageResourceName = nameof(SharedResource.ValidationRequired))]
        public int Gender { get; set; } = (int)UserGenederEnum.Male;

        [StringLength(FieldsSizeConst.User.PasswordHashMax, MinimumLength = FieldsSizeConst.User.PasswordHashMin, ErrorMessageResourceType = typeof(SharedResource), ErrorMessageResourceName = nameof(SharedResource.ValidationPasswordHash))]
        public string? PasswordHash { get; set; }
        [StringLength(FieldsSizeConst.User.PasswordSaltMax, MinimumLength = FieldsSizeConst.User.PasswordSaltMin, ErrorMessageResourceType = typeof(SharedResource), ErrorMessageResourceName = nameof(SharedResource.ValidationPasswordSalt))]
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
