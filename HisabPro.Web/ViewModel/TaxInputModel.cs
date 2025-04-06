using System.ComponentModel.DataAnnotations;

namespace HisabPro.Web.ViewModel
{
    public class TaxInputModel
    {
        [Required(ErrorMessage = "Annual income is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Income must be a positive number")]
        public decimal AnnualIncome { get; set; }
    }
}
