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

        [LocalizedRequired(ResourceKey.ValidationRequired)]
        [StringLength(FieldsSizeConst.User.NameMax, MinimumLength = FieldsSizeConst.User.NameMin, ErrorMessage = ResourceKey.ValidationName)]
        public string Name { get; set; }

        [LocalizedRequired(ResourceKey.ValidationRequired)]
        [StringLength(FieldsSizeCommonConst.Email.Max, MinimumLength = FieldsSizeCommonConst.Email.Min, ErrorMessage = ResourceKey.ValidationEmail)]
        [RegularExpression(FieldsSizeCommonConst.Email.RegEx, ErrorMessageResourceType = typeof(ResourceKey), ErrorMessageResourceName = nameof(ResourceKey.ValidationInvalidEmail))]
        public string Email { get; set; }

        [LocalizedRequired(ResourceKey.ValidationRequired)]
        [StringLength(FieldsSizeCommonConst.Mobile.Len, MinimumLength = FieldsSizeCommonConst.Mobile.Len, ErrorMessage = ResourceKey.ValidationMobile)]
        [RegularExpression(FieldsSizeCommonConst.Mobile.RegEx, ErrorMessage = ResourceKey.ValidationMobile)]
        public string Mobile { get; set; }

        [LocalizedRequired(ResourceKey.ValidationRequired)]
        public int UserRole { get; set; } = (int)EnumUserRole.User;

        [LocalizedRequired(ResourceKey.ValidationRequired)]
        public int Gender { get; set; } = (int)EnumGeneder.Male;

        [StringLength(FieldsSizeConst.User.PasswordHashMax, MinimumLength = FieldsSizeConst.User.PasswordHashMin, ErrorMessage = ResourceKey.ValidationPasswordHash)]
        public string? PasswordHash { get; set; }

        [StringLength(FieldsSizeConst.User.PasswordSaltMax, MinimumLength = FieldsSizeConst.User.PasswordSaltMin, ErrorMessage = ResourceKey.ValidationPasswordSalt)]
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
