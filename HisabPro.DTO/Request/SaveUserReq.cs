using HisabPro.Constants;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HisabPro.DTO.Request
{
    public class SaveUserReq
    {
        public int? Id { get; set; }
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
        [Display(Name = "User Role")]
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
