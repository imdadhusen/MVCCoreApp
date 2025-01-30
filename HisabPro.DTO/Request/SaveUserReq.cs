using HisabPro.Constants;
using HisabPro.Constants.Resources;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HisabPro.DTO.Request
{
    public class SaveUserReq
    {
        public int? Id { get; set; }
        [Required]
        [StringLength(FieldsSizeConst.User.NameMax, MinimumLength = FieldsSizeConst.User.NameMin, ErrorMessageResourceType = typeof(SharedResource), ErrorMessageResourceName = nameof(SharedResource.ValidationName))]
        public string Name { get; set; }
        [Required]
        [StringLength(FieldsSizeCommonConst.Email.Max, MinimumLength = FieldsSizeCommonConst.Email.Min, ErrorMessageResourceType = typeof(SharedResource), ErrorMessageResourceName = nameof(SharedResource.ValidationEmail))]
        [RegularExpression(FieldsSizeCommonConst.Email.RegEx, ErrorMessageResourceType = typeof(SharedResource), ErrorMessageResourceName = nameof(SharedResource.ValidationInvalidEmail))]
        public string Email { get; set; }
        [Required]
        [StringLength(FieldsSizeCommonConst.Mobile.Len, MinimumLength = FieldsSizeCommonConst.Mobile.Len, ErrorMessageResourceType = typeof(SharedResource), ErrorMessageResourceName = nameof(SharedResource.ValidationMobile))]
        [RegularExpression(FieldsSizeCommonConst.Mobile.RegEx, ErrorMessageResourceType = typeof(SharedResource), ErrorMessageResourceName = nameof(SharedResource.ValidationMobile))]
        public string Mobile { get; set; }
        [Required]
        [Display(ResourceType = typeof(SharedResource), Name = nameof(SharedResource.FieldUserRole))]
        public int UserRole { get; set; } = (int)UserRoleEnum.User;
        [Required]
        public int Gender { get; set; } = (int)UserGenederEnum.Male;
        public DateTime? PasswordChangedOn { get; set; }
        public bool MustChangePassword { get; set; }

        [JsonIgnore]
        public string? PasswordHash { get; set; }
        [JsonIgnore]
        public string? PasswordSalt { get; set; }
        [JsonIgnore]
        public int FailedLoginAttempts { get; set; }
        [JsonIgnore]
        public DateTime? LockoutEnd { get; set; }
    }
}
