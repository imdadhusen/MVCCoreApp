using System.ComponentModel.DataAnnotations;
using HisabPro.Constants;
using HisabPro.Constants.Resources;

namespace HisabPro.DTO.Request
{
    public class LoginDTO
    {
        [LocalizedRequired(ResourceKey.ValidationRequired)]
        [EmailAddress(ErrorMessage = ResourceKey.ValidationInvalidEmail)]
        [Display(Name = ResourceKey.FieldEmail)]
        public required string Email { get; set; }

        [LocalizedRequired(ResourceKey.ValidationRequired)]
        [DataType(DataType.Password)]
        [Display(Name = ResourceKey.FieldPassword)]
        public required string Password { get; set; }

        [Display(Name = ResourceKey.FieldRememberMe)]
        public bool RememberMe { get; set; }
    }
}
