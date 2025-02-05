using System.ComponentModel.DataAnnotations;
using HisabPro.Constants.Resources;

namespace HisabPro.DTO.Request
{
    public class LoginDTO
    {
        [Required(ErrorMessageResourceType = typeof(SharedResource), ErrorMessageResourceName = "ValidationRequiredEmail")]
        [EmailAddress(ErrorMessageResourceType = typeof(SharedResource), ErrorMessageResourceName = "ValidationInvalidEmail")]
        [Display(ResourceType = typeof(SharedResource), Name = nameof(SharedResource.FieldEmail))]
        public required string Email { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResource), ErrorMessageResourceName = "ValidationRequiredPassword")]
        [DataType(DataType.Password)]
        [Display(ResourceType = typeof(SharedResource), Name = nameof(SharedResource.FieldPassword))]
        public required string Password { get; set; }

        [Display(ResourceType = typeof(SharedResource), Name = nameof(SharedResource.FieldRememberMe))]
        public bool RememberMe { get; set; }
    }
}
