using System.ComponentModel.DataAnnotations;

namespace HisabPro.DTO
{
    public class RequiredIfLoggedInAttribute : ValidationAttribute
    {
        private readonly string _dependentProperty;

        public RequiredIfLoggedInAttribute(string dependentProperty)
        {
            _dependentProperty = dependentProperty;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var property = validationContext.ObjectType.GetProperty(_dependentProperty);
            if (property == null)
            {
                return new ValidationResult($"Unknown property: {_dependentProperty}");
            }

            var isLoggedIn = (bool)property.GetValue(validationContext.ObjectInstance);

            // If the user is logged in and CurrentPassword is null or empty, return a validation error
            if (isLoggedIn && string.IsNullOrWhiteSpace(value?.ToString()))
            {
                return new ValidationResult(ErrorMessage ?? "Current Password is required when logged in.");
            }

            return ValidationResult.Success;
        }
    }
}
