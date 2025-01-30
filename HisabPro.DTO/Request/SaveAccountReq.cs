using HisabPro.Constants;
using HisabPro.Constants.Resources;
using System.ComponentModel.DataAnnotations;

namespace HisabPro.DTO.Request
{
    public class SaveAccountReq
    {
        public int? Id { get; set; }
        [Required]
        [StringLength(FieldsSizeConst.Account.NameMax, MinimumLength = FieldsSizeConst.Account.NameMin, ErrorMessageResourceType = typeof(SharedResource), ErrorMessageResourceName = nameof(SharedResource.ValidationName))]
        public string Name { get; set; }
        [StringLength(FieldsSizeConst.Account.FullNameMax, ErrorMessageResourceType = typeof(SharedResource), ErrorMessageResourceName = nameof(SharedResource.ValidationFullName))]
        [Display(ResourceType = typeof(SharedResource), Name = nameof(SharedResource.FieldFullName))]
        public string FullName { get; set; }
        [StringLength(FieldsSizeCommonConst.Mobile.Len, MinimumLength = FieldsSizeCommonConst.Mobile.Len, ErrorMessageResourceType = typeof(SharedResource), ErrorMessageResourceName = nameof(SharedResource.ValidationMobile))]
        [RegularExpression(FieldsSizeCommonConst.Mobile.RegEx, ErrorMessageResourceType = typeof(SharedResource), ErrorMessageResourceName = nameof(SharedResource.ValidationMobile))]
        public string? Mobile { get; set; }
        [Display(ResourceType = typeof(SharedResource), Name = nameof(SharedResource.FieldIsActive))]
        public bool IsActive { get; set; }
    }
}
