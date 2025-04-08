using HisabPro.Constants;
using HisabPro.Constants.Resources;
using System.ComponentModel.DataAnnotations;

namespace HisabPro.Web.ViewModel
{
    public class TaxInputModel
    {
        [LocalizedRequired(ResourceKey.ValidationRequired)]
        [Range(0, int.MaxValue, ErrorMessage = ResourceKey.ValidationAmount)]
        public decimal AnnualIncome { get; set; }
    }
}
