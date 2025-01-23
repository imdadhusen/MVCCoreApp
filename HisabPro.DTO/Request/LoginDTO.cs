using System.ComponentModel.DataAnnotations;
using HisabPro.Constants.Resources;

namespace HisabPro.DTO.Request
{
    public class LoginDTO
    {
        [Required(ErrorMessageResourceType = typeof(SharedResource), ErrorMessageResourceName = "ValidationRequiredEmail")]
        [EmailAddress(ErrorMessageResourceType = typeof(SharedResource), ErrorMessageResourceName = "ValidationInvalidEmail")]
        [Display(Name = "FieldEmail", ResourceType = typeof(SharedResource))]
        public string Email { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResource), ErrorMessageResourceName = "ValidationRequiredPassword")]
        [DataType(DataType.Password)]
        [Display(Name = "FieldPassword", ResourceType = typeof(SharedResource))]
        public string Password { get; set; }

        [Display(Name = "FieldRememberMe", ResourceType = typeof(SharedResource))]
        public bool RememberMe { get; set; }
    }
}
