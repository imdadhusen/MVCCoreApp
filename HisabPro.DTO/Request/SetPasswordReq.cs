using HisabPro.Constants;
using System.ComponentModel.DataAnnotations;

namespace HisabPro.DTO.Request
{
    public class SetPasswordReq
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "New Password")]
        [StringLength(100, ErrorMessage = FieldsSizeConst.User.NewPasswordMessage, MinimumLength = FieldsSizeConst.User.NewPasswordMin)]
        public string NewPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("NewPassword", ErrorMessage = FieldsSizeConst.User.ConfirmPasswordMessage)]
        public string ConfirmPassword { get; set; }
    }

    public class ResetPasswordReq : SetPasswordReq
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current Password")]
        [Compare("NewPassword")]
        public string CurrentPassword { get; set; }
    }
}
