using HisabPro.Constants;
using HisabPro.Constants.Resources;
using System.ComponentModel.DataAnnotations;

namespace HisabPro.DTO.Request
{
    public class SaveAccountReq
    {
        public int? Id { get; set; }

        [LocalizedRequired(ResourceKey.ValidationRequired)]
        [StringLength(FieldsSizeConst.Account.NameMax, MinimumLength = FieldsSizeConst.Account.NameMin, ErrorMessage = ResourceKey.ValidationName)]
        [Display(Name = ResourceKey.FieldName)]
        public string Name { get; set; }

        [StringLength(FieldsSizeConst.Account.FullNameMax, ErrorMessage = ResourceKey.ValidationFullName)]
        [Display(Name = ResourceKey.FieldFullName)]
        public string FullName { get; set; }

        [StringLength(FieldsSizeCommonConst.Mobile.Len, MinimumLength = FieldsSizeCommonConst.Mobile.Len,  ErrorMessage = ResourceKey.ValidationMobile)]
        [RegularExpression(FieldsSizeCommonConst.Mobile.RegEx, ErrorMessage = ResourceKey.ValidationMobile)]
        [Display(Name = ResourceKey.FieldMobile)]
        public string? Mobile { get; set; }

        [Display(Name = ResourceKey.FieldIsActive)]
        public bool IsActive { get; set; }
    }
}
