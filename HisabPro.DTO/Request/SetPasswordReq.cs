using HisabPro.Constants;
using System.ComponentModel.DataAnnotations;

namespace HisabPro.DTO.Request
{
    public class SetPasswordReq
    {
        [Required]
        public int UserId { get; set; }

        //[RequiredIfLoggedIn(nameof(IsLoggedIn), ErrorMessage = "Current Password is required.")]
        //[DataType(DataType.Password)]
        //public string CurrentPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = FieldsSizeConst.User.NewPasswordMessage, MinimumLength = FieldsSizeConst.User.NewPasswordMin)]
        public string NewPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = FieldsSizeConst.User.ConfirmPasswordMessage)]
        public string ConfirmPassword { get; set; }

        //public bool IsLoggedIn { get; set; } // Set this flag in your controller
    }
}
