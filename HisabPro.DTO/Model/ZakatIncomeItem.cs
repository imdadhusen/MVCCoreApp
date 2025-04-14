using HisabPro.Constants.Resources;
using HisabPro.Constants;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.DependencyInjection;

namespace HisabPro.DTO.Model
{
    public class ZakatIncomeItem : IValidatableObject
    {
        // TODO: Check Other Id must be match
        private const int IncomeTypeForOther = 100;

        [LocalizedRequired(ResourceKey.ValidationRequired)]
        [Display(Name = ResourceKey.IncomeType)]
        public int IncomeType { get; set; }

        // Required only if IncomeType is "Other"
        [Display(Name = ResourceKey.Description)]
        public string? Description { get; set; } 

        [LocalizedRequired(ResourceKey.ValidationRequired)]
        [Range(0, int.MaxValue, ErrorMessage = ResourceKey.ValidationAmount)]
        [Display(Name = ResourceKey.FieldAmount)]
        public decimal Amount { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var localizer = validationContext.GetRequiredService<IStringLocalizer<SharedResource>>(); 
            if (IncomeType == IncomeTypeForOther && string.IsNullOrWhiteSpace(Description))
            {
                var errorMessage = string.Format(localizer[ResourceKey.ValidationRequired], localizer[ResourceKey.Description]);
                yield return new ValidationResult(errorMessage, [nameof(Description)]);
            }
        }
    }
}
