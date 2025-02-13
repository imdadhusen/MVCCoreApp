using HisabPro.Constants;
using HisabPro.Constants.Resources;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace HisabPro.DTO.Request
{
    public class SaveUserReq
    {
        public int? Id { get; set; }

        [LocalizedRequired(ResourceKey.ValidationRequired)]
        [StringLength(FieldsSizeConst.User.NameMax, MinimumLength = FieldsSizeConst.User.NameMin, ErrorMessage = ResourceKey.ValidationName)]
        [Display(Name = ResourceKey.FieldName)]
        public string Name { get; set; }

        [LocalizedRequired(ResourceKey.ValidationRequired)]
        [StringLength(FieldsSizeCommonConst.Email.Max, MinimumLength = FieldsSizeCommonConst.Email.Min, ErrorMessage = ResourceKey.ValidationEmail)]
        [RegularExpression(FieldsSizeCommonConst.Email.RegEx, ErrorMessage = ResourceKey.ValidationInvalidEmail)]
        [Display(Name = ResourceKey.FieldEmail)]
        public string Email { get; set; }

        [LocalizedRequired(ResourceKey.ValidationRequired)]
        [StringLength(FieldsSizeCommonConst.Mobile.Len, MinimumLength = FieldsSizeCommonConst.Mobile.Len, ErrorMessage = ResourceKey.ValidationMobile)]
        [RegularExpression(FieldsSizeCommonConst.Mobile.RegEx, ErrorMessage = ResourceKey.ValidationMobile)]
        [Display(Name = ResourceKey.FieldMobile)]
        public string Mobile { get; set; }

        [LocalizedRequired(ResourceKey.ValidationRequired)]
        [Display(Name = ResourceKey.FieldUserRole)]
        public int UserRole { get; set; } = (int)EnumUserRole.User;

        [LocalizedRequired(ResourceKey.ValidationRequired)]
        [Display(Name = ResourceKey.FieldGender)]
        public int Gender { get; set; } = (int)EnumGeneder.Male;

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
