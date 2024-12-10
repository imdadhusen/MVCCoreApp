using HisabPro.Constants;
using System.ComponentModel.DataAnnotations;

namespace HisabPro.DTO.Request
{
    public class SaveUser
    {
        public int? Id { get; set; }
        [Required]
        [StringLength(FieldsSizeConst.User.NameMax, MinimumLength = FieldsSizeConst.User.NameMin, ErrorMessage = FieldsSizeConst.User.NameMessage)]
        public string Name { get; set; }
        [StringLength(FieldsSizeCommonConst.Email.Max, MinimumLength = FieldsSizeCommonConst.Email.Min, ErrorMessage = FieldsSizeCommonConst.Email.Message)]
        [RegularExpression(FieldsSizeCommonConst.Email.RegEx, ErrorMessage = FieldsSizeCommonConst.Email.RegExMessage)]
        public string Email { get; set; }
        [StringLength(FieldsSizeCommonConst.Mobile.Len, MinimumLength = FieldsSizeCommonConst.Mobile.Len, ErrorMessage = FieldsSizeCommonConst.Mobile.Message)]
        [RegularExpression(FieldsSizeCommonConst.Mobile.RegEx, ErrorMessage = FieldsSizeCommonConst.Mobile.RegExMessage)]
        public string? Mobile { get; set; }
        [Required]
        public int UserRole { get; set; } = (int)UserRoleEnum.User;
        [Required]
        public int Gender { get; set; } = (int)UserGenederEnum.Male;
    }
}
