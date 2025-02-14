using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel.DataAnnotations;

namespace HisabPro.Constants
{
    public class LocalizedRequiredAttribute : RequiredAttribute, IClientModelValidator
    {
        private readonly string _resourceKey;

        public LocalizedRequiredAttribute(string resourceKey)
        {
            _resourceKey = resourceKey;
        }

        private string GetLocalizedMessage(IServiceProvider serviceProvider, string fieldName)
        {
            var localizer = serviceProvider.GetService<ISharedViewLocalizer>();
            var rawMessage = localizer?.Get(_resourceKey).Value ?? "{0} field is required.";
            fieldName = localizer?.Get(fieldName).Value ?? fieldName;
            return string.Format(rawMessage, fieldName);
        }

        private string GetDisplayName(ValidationContext validationContext)
        {
            var displayAttribute = validationContext.ObjectType
                .GetProperty(validationContext.MemberName)?
                .GetCustomAttributes(typeof(DisplayAttribute), true)
                .FirstOrDefault() as DisplayAttribute;

            return displayAttribute?.Name ?? validationContext.MemberName ?? "This field";
        }

        private string GetDisplayName(ClientModelValidationContext context)
        {
            var displayAttribute = context.ModelMetadata.ContainerType?
                .GetProperty(context.ModelMetadata.PropertyName)?
                .GetCustomAttributes(typeof(DisplayAttribute), true)
                .FirstOrDefault() as DisplayAttribute;

            return displayAttribute?.Name ?? context.ModelMetadata.PropertyName ?? "This field";
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var serviceProvider = validationContext.GetService<IServiceProvider>();
            var fieldName = GetDisplayName(validationContext); // Fetch display name correctly
            var errorMessage = GetLocalizedMessage(serviceProvider, fieldName);

            return string.IsNullOrWhiteSpace(value?.ToString())
                ? new ValidationResult(errorMessage)
                : ValidationResult.Success;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(_resourceKey, name); // For client-side validation compatibility
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            var serviceProvider = context.ActionContext.HttpContext.RequestServices;

            // Fetch display name explicitly
            var fieldName = GetDisplayName(context);

            var errorMessage = GetLocalizedMessage(serviceProvider, fieldName);

            context.Attributes["data-val"] = "true";
            context.Attributes["data-val-required"] = errorMessage;
        }
    }
}
