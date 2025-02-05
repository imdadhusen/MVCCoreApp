using HisabPro.Constants;
using HisabPro.Constants.Resources;
using System.ComponentModel.DataAnnotations;

namespace HisabPro.DTO.Request
{
    public class SetPasswordReq
    {
        [Required(ErrorMessageResourceType = typeof(SharedResource), ErrorMessageResourceName = nameof(SharedResource.ValidationRequired))]
        public int UserId { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResource), ErrorMessageResourceName = nameof(SharedResource.ValidationRequired))]
        [DataType(DataType.Password)]
        [Display(ResourceType = typeof(SharedResource), Name = nameof(SharedResource.LabelNewPassword))]
        [StringLength(100, MinimumLength = FieldsSizeConst.User.NewPasswordMin, ErrorMessageResourceType = typeof(SharedResource), ErrorMessageResourceName = nameof(SharedResource.ValidationPasswordNew))]
        public string NewPassword { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResource), ErrorMessageResourceName = nameof(SharedResource.ValidationRequired))]
        [DataType(DataType.Password)]
        [Display(ResourceType = typeof(SharedResource), Name = nameof(SharedResource.LabelConfirmPassword))]
        [Compare("NewPassword", ErrorMessageResourceType = typeof(SharedResource), ErrorMessageResourceName = nameof(SharedResource.ValidationPasswordConfirm))]
        public string ConfirmPassword { get; set; }
    }

    public class ResetPasswordReq : SetPasswordReq
    {
        [Required(ErrorMessageResourceType = typeof(SharedResource), ErrorMessageResourceName = nameof(SharedResource.ValidationRequired))]
        [DataType(DataType.Password)]
        [Display(ResourceType = typeof(SharedResource), Name = nameof(SharedResource.LabelCurrentPassword))]
        [Compare("NewPassword")]
        public string CurrentPassword { get; set; }
    }
}
