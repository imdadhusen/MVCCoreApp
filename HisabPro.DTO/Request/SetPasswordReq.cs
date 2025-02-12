using HisabPro.Constants;
using HisabPro.Constants.Resources;
using System.ComponentModel.DataAnnotations;

namespace HisabPro.DTO.Request
{
    public class SetPasswordReq
    {
        [LocalizedRequired(ResourceKey.ValidationRequired)]
        public int UserId { get; set; }

        [LocalizedRequired(ResourceKey.ValidationRequired)]
        [DataType(DataType.Password)]
        [Display(Name = ResourceKey.FieldNewPassword)]
        [StringLength(100, MinimumLength = FieldsSizeConst.User.NewPasswordMin, ErrorMessage = ResourceKey.ValidationPasswordNew)]
        public string NewPassword { get; set; }

        [LocalizedRequired(ResourceKey.ValidationRequired)]
        [DataType(DataType.Password)]
        [Display(Name = ResourceKey.FieldConfirmPassword)]
        [Compare("NewPassword", ErrorMessage = ResourceKey.ValidationPasswordConfirm)]
        public string ConfirmPassword { get; set; }
    }

    public class ResetPasswordReq : SetPasswordReq
    {
        [LocalizedRequired(ResourceKey.ValidationRequired)]
        [DataType(DataType.Password)]
        [Display(Name = ResourceKey.FieldCurrentPassword)]
        [Compare("NewPassword")]
        public string CurrentPassword { get; set; }
    }
}
