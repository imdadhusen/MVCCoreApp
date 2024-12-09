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
        [StringLength(FieldsSizeConst.User.EmailMax, MinimumLength = 5, ErrorMessage = FieldsSizeConst.User.EmailMessage)]
        [RegularExpression(FieldsSizeConst.User.EmailRegEx, ErrorMessage = FieldsSizeConst.User.EmailRegExMessage)]
        public string Email { get; set; }
        public int UserRole { get; set; } = (int)UserRoleEnum.User;
    }
}
