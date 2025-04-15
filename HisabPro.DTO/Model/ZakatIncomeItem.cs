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
        public static int IncomeTypeForOtherId = 1000;
        public static string IncomeTypeForOtherName = "Other";

        [LocalizedRequired(ResourceKey.ValidationRequired)]
        [Display(Name = ResourceKey.IncomeType)]
        public int IncomeType { get; set; }

        // Required only if IncomeType is "Other"
        [Display(Name = ResourceKey.Description)]
        public string? Description { get; set; } 

        [LocalizedRequired(ResourceKey.ValidationRequired)]
        [Range(1, int.MaxValue, ErrorMessage = ResourceKey.ValidationAmount)]
        [Display(Name = ResourceKey.FieldAmount)]
        public decimal Amount { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (IncomeType == IncomeTypeForOtherId && string.IsNullOrWhiteSpace(Description))
            {
                var localizer = validationContext.GetRequiredService<IStringLocalizer<SharedResource>>();
                var errorMessage = string.Format(localizer[ResourceKey.ValidationRequired], localizer[ResourceKey.Description]);
                yield return new ValidationResult(errorMessage, [nameof(Description)]);
            }
        }
    }
}
